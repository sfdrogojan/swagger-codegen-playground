:: Run Unit Tests

SET NUNITCONSOLEPATH=..\openapi-2.0\generated\packages\NUnit.ConsoleRunner.3.10.0\tools

%NUNITCONSOLEPATH%\nunit3-console.exe ..\openapi-2.0\generated\src\IO.Swagger.UnitTests\bin\Release\IO.Swagger.UnitTests.dll  --result=UnitTestsResult.xml

if %errorlevel% neq 0 exit %errorlevel%