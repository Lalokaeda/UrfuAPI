файл appsettings.json:  
изменить UrfuDbConnectionString на свою строку подключения  
удалить папку "Migrations"

В терминале:  
dotnet ef migrations add CreateTableArticles  
dotnet ef database update  

На вашем MS Sql сервере создастся база с пустой таблицей, перед тестом ее надо заполнить данными

В файле Program.cs:
Есть комментарий, там нужно будет добавить адрес. Указанный URL-адрес не должен содержать косую черту (/).

Для запуска:  
//доверие сертификату разработки  
dotnet dev-certs https --trust  
//сам запуск  
dotnet run --launch-profile https  
//для проверки работы  
https://localhost:port/swagger  
ctrl+c - остановить  
