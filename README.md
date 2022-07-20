# WpfApplication

Небольшое приложение.
Для работы сервера, нужно создать базу данных. Для этого применим миграцию.
В VSCode, открыв терминал, нужно перейти в папку Server/Infrastructure и применить команду.

`dotnet ef database update --startup-project ..\WebApi\WebApi.csproj`

Далее из папки Server/WebApi запустить сервер командой 

`dotnet run`

Клиент запускается из Client/WpfApplication командой

`dotnet run`
