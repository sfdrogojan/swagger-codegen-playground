@echo off

REM SET MSBUILDPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319
SET MSBUILDPATH="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"
REM SET MSBUILDPATH="C:\Program Files (x86)\MSBuild\14.0\Bin"

if not exist ".\nuget.exe" powershell -Command "(new-object System.Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '.\nuget.exe')"
REM .\nuget.exe install src\IO.Swagger\packages.config -o packages
SET SOLUTIONPATH = IO.Swagger.sln
.\nuget.exe restore %SOLUTIONPATH%

%MSBUILDPATH%\MSBuild.exe IO.Swagger.sln -tv:14.0 /p:Configuration=Release /p:Platform="Any CPU"

pushd "..\..\scripts"
REM cd ..\..\scripts

CALL build-custom-csharp-generator.bat

if %errorlevel% neq 0 exit /b %errorlevel%

CALL run-unit-tests.bat

if %errorlevel% neq 0 exit /b %errorlevel%

CALL run-integration-tests.bat

if %errorlevel% neq 0 exit /b %errorlevel%

popd
REM cd ..\openapi-2.0\generated

REM Pushd "%~dp0"
REM CALL ..\..\scripts\run-unit-tests.bat
REM Popd
REM echo %~dp0

REM CALL run-unit-tests.bat

REM if %errorlevel% neq 0 exit /b %errorlevel%

REM :: Run Unit Tests
REM SET NUNITCONSOLEPATH=packages\NUnit.ConsoleRunner.3.10.0\tools

REM %NUNITCONSOLEPATH%\nunit3-console.exe src\IO.Swagger.UnitTests\bin\Release\IO.Swagger.UnitTests.dll

REM if %errorlevel% neq 0 exit /b %errorlevel%

REM :: Run Integration Tests

REM %NUNITCONSOLEPATH%\nunit3-console.exe src\IO.Swagger.Test\bin\Release\IO.Swagger.Test.dll

REM if %errorlevel% neq 0 exit /b %errorlevel%