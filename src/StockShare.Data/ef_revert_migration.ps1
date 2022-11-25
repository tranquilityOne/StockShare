$EntryProject = "$PSScriptRoot/../StockShare/StockShare.API.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"
$DbContext = "StockShareContext"

dotnet ef migrations remove -s $EntryProject -p $Project --context $DbContext
