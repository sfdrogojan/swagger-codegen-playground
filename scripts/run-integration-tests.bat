:: Run Integration Tests

SET NUNITCONSOLEPATH=..\openapi-2.0\generated\packages\NUnit.ConsoleRunner.3.10.0\tools

%NUNITCONSOLEPATH%\nunit3-console.exe ^
    ..\openapi-2.0\generated\src\Salesforce.MarketingCloud.Test\bin\Release\Salesforce.MarketingCloud.Test.dll ^
    --result=IntegrationTestsResult.xml ^
    --work=..\build-artifacts

if %errorlevel% neq 0 exit %errorlevel%