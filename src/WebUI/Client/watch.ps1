dotnet build -p:TailwindBuild=false
start "dotnet" -ArgumentList "watch"
while (!(Test-Path "./node_modules/.package-lock.json")) { sleep 1 }
npm run watch