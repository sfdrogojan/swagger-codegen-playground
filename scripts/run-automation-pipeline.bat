@echo off

CALL build-custom-csharp-generator.bat

CALL generate-csharp-api-client.bat

REM CALL build-solution.bat
CALL build-solution-core.bat

CALL run-unit-tests.bat

CALL run-integration-tests.bat

CALL create-nuget-package.bat

bash ./git-push.sh

echo "Success!"