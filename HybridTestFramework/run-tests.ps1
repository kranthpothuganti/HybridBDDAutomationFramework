$tag = $env:TAG

if (-not $tag) {
    Write-Error "TAG environment variable is not set."
    exit 1
}

$testResultsDir = "TestResults\$tag"
$reportOutput = "reports\$tag"

# Ensure folders
New-Item -ItemType Directory -Force -Path $testResultsDir, $reportOutput | Out-Null

# Run tests filtered by tag
dotnet test WebTests/WebTests.csproj `
    --filter "TestCategory=$tag" `
    --logger "trx;LogFileName=$testResultsDir\test_results.trx" `
    --no-build `
    --verbosity normal

# Generate LivingDoc report
dotnet livingdoc test-assembly `
    WebTests/bin/Debug/net9.0/WebTests.dll `
    -t $testResultsDir/test_results.trx `
    -o $reportOutput/LivingDoc.html
