﻿using System.Net;
using BotLooter.Resources;
using BotLooter.Steam.Contracts;

namespace BotLooter.Steam;

public class Looter
{
    public async Task Loot(List<SteamAccountCredentials> accountCredentials, ProxyPool proxyPool, TradeOfferUrl tradeOfferUrl)
    {
        foreach (var credentials in accountCredentials)
        {
            var restClient = proxyPool.Provide();

            var session = new SteamSession(credentials, restClient);
            
            Console.WriteLine($"{credentials.Login}: Лутаю");

            if (!await session.TryEnsureSession())
            {
                Console.WriteLine($"{credentials.Login}: Не смог получить валидную сессию");
                continue;
            }
            
            var web = new SteamWeb(session);
        
            var inventoryResponse = await web.GetInventory(credentials.SteamGuardAccount.Session.SteamID, 730, 2);

            if (inventoryResponse.Data is not { } inventoryData)
            {
                Console.WriteLine($"{credentials.Login}: Не смог получить инвентарь - {inventoryResponse.StatusCode}");
                continue;
            }

            if (inventoryData.Assets is null || inventoryData.Assets.Count < 1)
            {
                Console.WriteLine($"{credentials.Login}: Пустой инвентарь");
                continue;
            }

            var tradeOffer = new JsonTradeOffer
            {
                NewVersion = true,
                Version = 4
            };
        
            foreach (var inventoryAsset in inventoryData.Assets)
            {
                var asset = new TradeOfferAsset
                {
                    AppId = "730",
                    ContextId = "2",
                    Amount = 1,
                    AssetId = inventoryAsset.Assetid
                };
            
                tradeOffer.Me.Assets.Add(asset);
            }

            var sendTradeOfferResponse = await web.SendTradeOffer(tradeOfferUrl, tradeOffer);

            if (sendTradeOfferResponse.StatusCode != HttpStatusCode.OK ||
                sendTradeOfferResponse.Data is not {} sendTradeOfferData || 
                !ulong.TryParse(sendTradeOfferData.TradeofferId, out var tradeOfferId))
            {
                Console.WriteLine($"{credentials.Login}: Не смог отправить обмен - {sendTradeOfferResponse.StatusCode} {sendTradeOfferResponse.Content}");
                continue;
            }

            var confirmationResult = await session.AcceptConfirmation(tradeOfferId);

            if (!confirmationResult)
            {
                Console.WriteLine($"{credentials.Login}: Не смог подтвердить обмен");
                continue;
            }
            
            Console.WriteLine($"{credentials.Login}: Залутан! Предметов: {tradeOffer.Me.Assets.Count}");

            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}