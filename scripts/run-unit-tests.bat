:: Run Unit Tests

SET NUNITCONSOLEPATH=..\openapi-2.0\generated\packages\NUnit.ConsoleRunner.3.10.0\tools

%NUNITCONSOLEPATH%\nunit3-console.exe ^
    ..\openapi-2.0\generated\src\Salesforce.MarketingCloud.UnitTests\bin\Release\Salesforce.MarketingCloud.UnitTests.dll ^
    --result=UnitTestsResult.xml ^
    --work=..\build-artifacts

if %errorlevel% neq 0 exit %errorlevel%