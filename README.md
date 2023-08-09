## Описание

Софт позволяет передать предметы от нескольких Steam аккаунтов на один.
Кратко - Лутать ботов.

## Функционал

- Лутание любых инвентарей, например стим, кс, дота, тф2 и т.д.
- Многопоточное или однопоточного лутание.
- Использование прокси.

## Конфиг

BotLooter.Config.json

```json
{
  "LootTradeOfferUrl": "",
  
  "SecretsDirectoryPath": "",
  "AccountsFilePath": "",
  "SteamSessionsDirectoryPath": "",
  "ProxiesFilePath": "proxies.txt",
  
  "DelayBetweenAccountsSeconds": 30,
  "DelayInventoryEmptySeconds": 10,
  
  "AskForApproval": true,
  "ExitOnFinish": false,
  
  "LootThreadCount": 1,
  
  "Inventories": [
    "440/2"
  ],
  
  "IgnoreNotMarketable": false,
  "IgnoreMarketable": false,

  "LootOnlyItemsWithNames": [
    "Mann Co. Supply Crate Key",
    "Tour of Duty Ticket",
  ],

  "IgnoreItemsWithNames": [
    "The Frying Pan"
  ]
}
```

---

### `"LootTradeOfferUrl"`
Cсылка на трейд оффер, на который будут отправляться предметы.
\
Для работы необходимо скопировать полную актуальную ссылку. Пример.
- `"https://steamcommunity.com/tradeoffer/new/?partner=9639579492&token=2ix22Ruv2"`

---

### `"SecretsDirectoryPath"`
Путь к папке с МаФайлами.

---

### `"AccountsFilePath"`
Путь к файлу с аккаунтами формата login:password

---

### `"SteamSessionsDirectoryPath"`
Путь к папке с файлами .steamsession.
\
Так же можно часть аккаунтов загружать из МаФайлов, а часть из .steamsession файлов.
\
Создать такие файлы можно с помощью https://github.com/Sadzurami/steam-sessions-creator

---

### `"ProxiesFilePath"`
Путь к файлу с прокси. Пример.
- `"http://username:password@192.168.1.80:25565"`
- `"http://192.168.1.80:8080"`

---

### `"DelayBetweenAccountsSeconds"`
Задержка при успешном и ошибочном лутаниях.
\
Указывается в секундах.

---

### `"DelayInventoryEmptySeconds"`
Задержка при пустом инвентаре.
\
Указывается в секундах.

---

### `"AskForApproval"`
- `true` - Будет требоваться подтверждение нажатием любой клавиши.
- `false` - 5 секундное ожидание без подтверждения начала работы.

---

### `"ExitOnFinish"`
- `true` - Программа сама закроется через 5 секунд после завершения работы.
- `false` - Программа будет ждать нажатия `ctrl + c` для закрытия.

---

### `"LootThreadCount"`
Максимальное количество потоков для лутания.
\
Не может быть больше количества прокси.
\
Без прокси может быть только `1`

---

### `"Inventories"`
Список инвентарей для лутания. Можно указывать один или несколько.
\
Формат `"appId/contextId"`

Некоторые известные инвентари:
- `"730/2"` - CS:GO
- `"753/6"` - Steam Community
- `"440/2"` - TF2

Пример, который будет лутать все 3 вышеперчисленные инвентаря.
```json
"Inventories": [
  "730/2",
  "753/6",
  "440/2"
]
```

---

### `"IgnoreNotMarketable"`
- `true` - Предметы, которые невозможно продать будут игнорироваться.
- `false` - Значение по умолчанию.

---

### `"IgnoreMarketable"`
- `true` - Предметы, которые возможно продать будут игнорироваться.
- `false` - Значение по умолчанию.

---

### `"LootOnlyItemsWithNames"`
Список предметов, которые будут лутаться.
Если список пустой, то будут лутаться все предметы.

Пример, который будет лутать только TF2 ключи и билеты.
```json
"LootOnlyItemsWithNames": [
    "Mann Co. Supply Crate Key",
    "Tour of Duty Ticket",
]
```

---

### `"IgnoreItemsWithNames"`
Список предметов, которые будут игнорироваться.
Если список пустой, то никакие предметы не будут игнорироваться.

Пример, который будет игнорировать только сковородки.
```json
"IgnoreItemsWithNames": [
    "The Frying Pan"
  ]
```

---

## Замечания
Особенности работы, подсказки и ответы на некоторые вопросы.

### Пути
Пути в конфиге можно указать как локальные, так и полные.
\
В случае написания с бекслешем необходимо заменять `\` на `\\` примеры:
- `"C:\\Users\\BestUser\\Desktop\\SSF\\secrets"`
- `".\\secrets"`
- `"secrets"`
- `"accounts.txt"`
- `"./accounts.txt"`

### Названия предметов для фильтров
Название предметов необходимо указывать на английском языке.
Если предмет был переименован, нужно указывать его основное название.

## Примеры
![Скриншот работы софта](Assets/Screenshot.png)
