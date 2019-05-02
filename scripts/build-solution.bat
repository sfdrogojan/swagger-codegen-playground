@echo off

pushd "..\openapi-2.0\generated"

SET MSBUILDPATH="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"

if not exist ".\nuget.exe" powershell -Command "(new-object System.Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '.\nuget.exe')"
SET SOLUTIONPATH = IO.Swagger.sln
.\nuget.exe restore %SOLUTIONPATH%

%MSBUILDPATH%\MSBuild.exe IO.Swagger.sln -tv:14.0 /p:Configuration=Release /p:Platform="Any CPU"

if %errorlevel% neq 0 exit %errorlevel%

popd