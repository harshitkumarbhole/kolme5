
# Kolme.API

## Run Locally

1. Restore packages:
   dotnet restore

2. Apply migrations & seed:
   dotnet ef database update

3. Run the API:
   dotnet run

4. Swagger UI:
   https://localhost:5001/swagger

## EF Core
To regenerate migrations:
   dotnet ef migrations remove
   dotnet ef migrations add InitialCreate

