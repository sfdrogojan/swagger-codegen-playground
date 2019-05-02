@echo off

CALL build-custom-csharp-generator.bat

CALL generate-csharp-api-client.bat

CALL build-solution.bat

CALL run-unit-tests.bat

CALL run-integration-tests.bat

echo "Success!"