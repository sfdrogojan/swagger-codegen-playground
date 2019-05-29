@echo off

CALL build-custom-csharp-generator.bat

CALL generate-csharp-api-client.bat

CALL build-solution-core.bat

CALL run-unit-tests.bat

REM CALL run-integration-tests.bat

CALL create-nuget-package.bat

REM bash ./git-push.sh

echo "Success!"