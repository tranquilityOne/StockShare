$EntryProject = "$PSScriptRoot/../StockShare/StockShare.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"
$DbContext = "StockShareContext"

dotnet ef database update -s $EntryProject -p $Project --context $DbContext
