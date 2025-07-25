## Biogenom

### Сборка
- В корневой директории есть compose.yml. Из корневой директории в терминале введите команду ```docker-compose up -d --build```. После этого приложение будет слушать адрес localhost:8080

### REST API
- Postman collection[1]
  - https://api.postman.com/collections/36770351-2ca91e77-5415-43cc-9cc2-0e3307e88626?access_key=PMAT-01JZZ9CSKSXWEY92J5NQ9SXEDR
- Controllers
  - GET "/" - Hello from root
  - GET "/health" - проверка работоспособности сервера. Вернет "Healthy", если сервер запущен и успешно работает
  - GET "/diagnosis/result" - вернет последний результат оценки качества питания[2]
  - POST "/diagnosis/result" - записать результат оценки качества питания [3]

### Принятые решения
- Разделение на слои API и Persistence - часть луковой архитектуры
- По умолчанию в бд создается список доступных нутриентов: вода, витамин С, витамин B6, витамин D, цинк и йод (взято из скриншотов)

### Схема БД
<img width="588" height="696" alt="image" src="https://github.com/user-attachments/assets/d60c7b39-5a6e-41b4-b32c-72f9d9036537" />


### Примечания
[1] Импорт postman коллекции:
  1. Перейти по ссылке и скопировать весь json файл
  2. В desktop версии postman, во вкладке "Collections" нажать "Import"
  3. Вставить скопированный json файл
  4. Добавится новая коллекция с 3-мя REST-запросами

[2] По умолчанию в бд нет никаких данных об оценках

[3] Формат POST-запроса:
{
  "values": [
    {
      "name": "string",
      "value": 0
    }
  ]
}
