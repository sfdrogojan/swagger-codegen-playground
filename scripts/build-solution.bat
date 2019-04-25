@echo off

SET MSBUILDPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319

if not exist ".\nuget.exe" powershell -Command "(new-object System.Net.WebClient).DownloadFile('https://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '.\nuget.exe')"
REM .\nuget.exe install src\IO.Swagger\packages.config -o packages
SET SOLUTIONPATH = ..\openapi-2.0\generated\IO.Swagger.sln
.\nuget.exe restore %SOLUTIONPATH%
REM .\nuget.exe restore ..\openapi-2.0\generated\IO.Swagger.sln

echo batchfile=%0
echo full=%~f0
setlocal
::http://stackoverflow.com/questions/636381/what-is-the-best-way-to-do-a-substring-in-a-batch-file
  set Directory=%~dp0
echo Directory=%Directory%
:: strip trailing backslash
  set Directory=%Directory:~0,-1%
echo %Directory%
::  ~dp does not work for regular environment variables:
::  set ParentDirectory=%Directory:~dp%  set ParentDirectory=%Directory:~dp%
::  ~dp only works for batch file parameters and loop indexes
    for %%d in (%Directory%) do set ParentDirectory=%%~dpd
    echo ParentDirectory=%ParentDirectory%

    echo Start Time - %Time%
    %MSBUILDPATH%\MSBuild.exe %ParentDirectory%openapi-2.0\generated\IO.Swagger.sln -tv:12.0 /p:Configuration=Release /p:Platform="Any CPU"
    echo End Time - %Time%
  
endlocal



REM SET /p Wait=Build Process Completed...

REM if not exist ".\bin" mkdir bin

REM copy packages\Newtonsoft.Json.10.0.3\lib\net45\Newtonsoft.Json.dll bin\Newtonsoft.Json.dll
REM copy packages\JsonSubTypes.1.2.0\lib\net45\JsonSubTypes.dll bin\JsonSubTypes.dll
REM copy packages\RestSharp.105.1.0\lib\net45\RestSharp.dll bin\RestSharp.dll
REM %CSCPATH%\csc  /reference:bin\Newtonsoft.Json.dll;bin\JsonSubTypes.dll;bin\RestSharp.dll;System.ComponentModel.DataAnnotations.dll  /target:library /out:bin\IO.Swagger.dll /recurse:src\IO.Swagger\*.cs /doc:bin\IO.Swagger.xml

