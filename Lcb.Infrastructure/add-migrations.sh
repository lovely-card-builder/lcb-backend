export ASPNETCORE_ConnectionStrings__MainDb='Host=localhost\;Username=postgres\;Password=root\;Database=Lcb'
dotnet ef migrations add Updates -o Data/Migrations --startup-project '../Lcb.Web'
read -p "Press enter to continue"