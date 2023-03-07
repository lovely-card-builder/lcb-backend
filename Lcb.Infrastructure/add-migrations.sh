export ASPNETCORE_ConnectionStrings__hack4good='Host=localhost\;Username=postgres\;Password=root\;Database=hack4good'
dotnet ef migrations add Quiz -o Data/Migrations -s '../hack4good.Web'
read -p "Press enter to continue"