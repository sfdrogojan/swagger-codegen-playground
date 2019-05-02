cd ../generators/csharp

mvn clean package & cd ../../scripts

if %errorlevel% neq 0 exit /b %errorlevel%