:: Run Unit Tests

dotnet test ..\openapi-2.0\generated\src\Salesforce.MarketingCloud.UnitTests\Salesforce.MarketingCloud.UnitTests.csproj ^
    --results-directory:..\..\..\..\build-artifacts ^
    --logger:trx ^
    --verbosity:minimal

if %errorlevel% neq 0 exit %errorlevel%