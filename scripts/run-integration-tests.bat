:: Run Integration Tests

SET NUNITCONSOLEPATH=..\openapi-2.0\generated\packages\NUnit.ConsoleRunner.3.10.0\tools

%NUNITCONSOLEPATH%\nunit3-console.exe ..\openapi-2.0\generated\src\IO.Swagger.Test\bin\Release\IO.Swagger.Test.dll --result=IntegrationTestsResult.xml

if %errorlevel% neq 0 exit %errorlevel%