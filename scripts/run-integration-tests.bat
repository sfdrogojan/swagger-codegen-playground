:: Run Integration Tests

dotnet test ..\openapi-2.0\generated\src\Salesforce.MarketingCloud.Test\Salesforce.MarketingCloud.Test.csproj ^
    --results-directory:..\..\..\..\build-artifacts ^
    --logger:trx

if %errorlevel% neq 0 exit %errorlevel%