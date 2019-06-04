#!/bin/sh
ROOT_DIRECTORY=$(dirname $(dirname $(readlink -f "$0")))
CLI_JAR="$ROOT_DIRECTORY/cli/swagger-codegen-cli-3.0.8.jar"
java -jar $CLI_JAR generate -l csharp -i ../openapi-3.0/sfmc-openapi-v3.json -o ../openapi-3.0/generated-swagger-codegen-v3 -c ../openapi-2.0/swagger-codegen-config.json -t C:/GIT/swagger-codegen-generators/src/main/resources/mustache/csharp --template-engine 'mustache'
exit $?