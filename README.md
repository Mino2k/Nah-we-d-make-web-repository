# Вас приветствует команда "NAH, WE'D MAKE WEB" 👋

## Состав команды:

|**Участник**                                 |**Роль в проекте**           |
|---------------------------------------------|-----------------------------|
|Сорокин Юрий Павлович                        |frontend-разработчик         |
|Соловьев Александр Владимирович              |дизайнер                     |
|Бельков Трофим Александрович                 |аналитик                     |
|Яковлев Алексей Ильич                        |backend-разработчик          |
|Рычков Владимир Алексеевич                   |Тимлид                       |
|Черников Александр Алексеевич                |дизайнер                     |

## Актуальный статус сервиса💓:

[![Backend](https://github.com/Mino2k/Nah-we-d-make-web-repository/actions/workflows/backend.yml/badge.svg)](https://github.com/Mino2k/Nah-we-d-make-web-repository/actions/workflows/backend.yml)
[![Frontend](https://github.com/Mino2k/Nah-we-d-make-web-repository/actions/workflows/frontend.yml/badge.svg)](https://github.com/Mino2k/Nah-we-d-make-web-repository/actions/workflows/frontend.yml)

- Адрес нашего сервиса: [pp.yakovlev05.ru](https://pp.yakovlev05.ru/)
- Документация по API: [pp.yakovlev05.ru/swagger](https://pp.yakovlev05.ru/swagger)

## Немного о проекте 📋

Проект выполнен в рамках проектного практикума 2 семестра (1 курса, 2023-2024)
Сделан сервис для публикации рецептов (преимущественно мясные).

## Стек технологий 🧑‍💻

- backend: ASP.NET Core    ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
- frontent: React JS    ![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)

## Как запустить 🗝️

🐋==❤️\
Весь сервис разворачивается при помощи докера 🐋. \
Всё, что необходимо сделать это клонировать репозиторий, **заполнить docker-compose.yml** файл своими переменными (по типу пароля бд и т.п.) и ввести  ```docker compose up -d```

Клонируем репозиторий 🍀
```
git clone https://github.com/Mino2k/Nah-we-d-make-web-repository.git
```

Переходим в репозиторий 📁
```
cd Nah-we-d-make-web-repository
```

Запускаем docker 
```
docker compose up -d
```

Уже сейчас можете перейти по адресу ```localhost``` и увидеть работающий сервис
