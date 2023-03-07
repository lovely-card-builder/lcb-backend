export ASPNETCORE_ConnectionStrings__hack4good='Host=localhost;Port=5432;Username=postgres;Password=root;Database=hack4good'
dotnet ef database update -s '../hack4good.Web'
read -p "Press enter to continue"