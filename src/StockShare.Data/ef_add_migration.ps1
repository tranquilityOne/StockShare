param (
    [string]$name = $(Read-Host 'What is the name of this migration')
)

$EntryProject = "$PSScriptRoot/../StockShare/StockShare.API.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"
$DbContext = "StockShareContext"

dotnet ef migrations add $name -s $EntryProject -p $Project --context $DbContext
