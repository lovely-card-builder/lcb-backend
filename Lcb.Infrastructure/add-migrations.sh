export ASPNETCORE_ConnectionStrings__MainDb='Host=localhost\;Username=postgres\;Password=root\;Database=Lcb'
dotnet ef migrations add Init -o Data/Migrations -s '../Lcb.Web'
read -p "Press enter to continue"