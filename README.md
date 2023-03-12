Реализовано REST-API для учёта автомобилей.

API содержит следующие эндпоинты
1) получения JWT токена при помощи логина и пароля (токен генирирует в самом приложении) (/token).
2) получение данных, должна возможность получать не все данные а часть данных(с 1 записи по 10, с 3 по 8 и так далее)(/cars_filter)
3) получение всех данных(/cars), получение по id (/car/{id}), добавление (/car_create), обновление(/car_edit/{id}), удаление (/car_delete/{id}) данных.
Подключен к API swagger.
Для взаимодействия с базой данных используется Dapper
