# Рецептовоз

---

В данном репозитории представлено веб-приложение, реализующее архитектурный паттерн MVC и использующее технологию ASP.NET. Тематика приложения - курсовой проект "кулинарный сайт".

Были реализованы следующие страницы:
* главная
* новости
* поиск рецепта
* добавление рецепта
* просмотр рецепта

Перечисленные страницы подробно описаны ниже.

---

На всех страницах присутствуют две навигационные панели, позволяющие быстро добраться до других страниц.

![main_page](/assets/main_page.png)

---

На странице новостей можно посмотреть статьи, загружаемые из базы данных на удаленном сервере. Опубликовать новость может только администратор.

![news_page](/assets/news_page.png)

---

Следующая страница показывает все рецепты, удовлетворяющие введенным фильтрам.

![find_recipe_1](/assets/find_recipe_1.png)

![find_recipe_2](/assets/find_recipe_2.png)

---

Перейдя по ссылке с тексом "поделиться своим рецептом" на странице поиска рецепта, можно увидеть форму для загрузки своего рецепта.

![add_recipe](/assets/add_recipe.png)

Валидация формы реализована с помощью JavaScript и Bootstrap.

![add_recipe_errors](/assets/add_recipe_errors.png)

---

Выбрав нужный рецепт на странице рецептов и кликнув "Перейти к рецепту", можно увидеть подробную инфомацию о нем.

![recipe_page](/assets/recipe_page.png)

---

Описанное веб-приложение размещено на хостинге somee.com по адресу *http://receptovoz.somee.com*
