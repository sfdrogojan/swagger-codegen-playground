#!/bin/sh
ROOT_DIRECTORY=$(dirname $(dirname $(readlink -f "$0")))
CLI_JAR="${ROOT_DIRECTORY}/cli/swagger-codegen-cli-2.4.4.jar"
CUSTOM_GENERATOR_JAR="${ROOT_DIRECTORY}/generators/csharp/target/csharp-swagger-codegen-1.0.0.jar"
java -cp $CUSTOM_GENERATOR_JAR:$CLI_JAR io.swagger.codegen.SwaggerCodegen generate -l csharp -i ../openapi-2.0/sfmc-openapi-v2.json -o ../openapi-2.0/generated -c ../openapi-2.0/swagger-codegen-config.json
exit $?