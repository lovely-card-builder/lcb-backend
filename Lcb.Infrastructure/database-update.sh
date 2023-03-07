export ASPNETCORE_ConnectionStrings__MainDb='Host=localhost;Port=5432;Username=postgres;Password=root;Database=Lcb'
dotnet ef database update -s '../Lcb.Web'
read -p "Press enter to continue"