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
endlocal