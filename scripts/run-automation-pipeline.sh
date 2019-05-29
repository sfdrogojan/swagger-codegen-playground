#!/bin/sh
set -e

bash build-custom-csharp-generator.sh

# bash generate-csharp-api-client.sh

bash build-solution-core.sh

bash run-unit-tests.sh

# bash run-integration-tests.sh

bash create-nuget-package.sh

# bash ./git-push.sh