param (
    [string]$from = $(Read-Host 'Input from migration name, please'), #Do not contain 'from migration' changes
    [string]$to = $(Read-Host 'Input to migration name, please'),
    [string]$file = $(Read-Host 'Input output file name, please')
)

$EntryProject = "$PSScriptRoot/../StockShare/StockShare.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"

dotnet ef migrations script $from $to -s $EntryProject -p $Project --context StockShareContext -o ./Scripts/$file
