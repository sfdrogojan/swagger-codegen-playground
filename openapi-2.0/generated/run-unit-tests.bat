:: Run Unit Tests
SET NUNITCONSOLEPATH=packages\NUnit.ConsoleRunner.3.10.0\tools

%NUNITCONSOLEPATH%\nunit3-console.exe src\IO.Swagger.UnitTests\bin\Release\IO.Swagger.UnitTests.dll

if %errorlevel% neq 0 exit /b %errorlevel%