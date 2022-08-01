$EntryProject = "$PSScriptRoot/../StockShare/StockShare.csproj"
$Project = "$PSScriptRoot/StockShare.Data.csproj"
$DbContext = "StockShareContext"
$ProcessList = @(
    [pscustomobject]@{
        File = "$PSScriptRoot/../StockShare/Program.cs";
        OriginalCodePattern = '^(\s*)(service.AddHostedService)';
        CommentedOutCodePattern = '^(\s*)//\s*(service.AddHostedService)';
    }
)

foreach ($processData in $ProcessList)
{
    (Get-Content -Encoding UTF8 -Path $processData.File) -replace $processData.OriginalCodePattern,'$1// $2' | Set-Content -Encoding UTF8 $processData.File
}

dotnet ef database update -s $EntryProject -p $Project --context $DbContext

foreach ($processData in $ProcessList)
{
    (Get-Content -Encoding UTF8 -Path $processData.File) -replace $processData.CommentedOutCodePattern,'$1$2' | Set-Content -Encoding UTF8 $processData.File
}
