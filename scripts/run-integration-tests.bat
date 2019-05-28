:: Run Integration Tests

dotnet test ..\openapi-2.0\generated\src\Salesforce.MarketingCloud.Test\Salesforce.MarketingCloud.Test.csproj ^
    --logger:console

if %errorlevel% neq 0 exit %errorlevel%