param($migration_name)

dotnet ef migrations add $migration_name --project src\Infrastructure --startup-project src\WebUI\Server --output-dir Persistence\Migrations