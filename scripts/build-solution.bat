@echo off

SET MSBUILDPATH="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"

if not exist "..\build-artifacts\nuget.exe" powershell -Command "(new-object System.Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '..\build-artifacts\nuget.exe')"

pushd "..\openapi-2.0\generated"

SET SOLUTIONPATH = Salesforce.MarketingCloud.sln
..\..\build-artifacts\nuget.exe restore %SOLUTIONPATH%

%MSBUILDPATH%\MSBuild.exe Salesforce.MarketingCloud.sln -tv:14.0 /p:Configuration=Release /p:Platform="Any CPU"

popd

if %errorlevel% neq 0 exit %errorlevel%