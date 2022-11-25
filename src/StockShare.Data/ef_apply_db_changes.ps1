$EntryProject = "$PSScriptRoot/../StockShare/StockShare.API.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"
$DbContext = "StockShareContext"

dotnet ef database update -s $EntryProject -p $Project --context $DbContext
