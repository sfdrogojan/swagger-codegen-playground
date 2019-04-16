java -cp ../generators/csharp/target/csharp-swagger-codegen-1.0.0.jar;../cli/swagger-codegen-cli.jar ^
 io.swagger.codegen.SwaggerCodegen generate -l csharp ^
 -i ../openapi-2.0/sfmc-openapi-v2.json ^
 -o ../openapi-2.0/generated ^
 -c ../openapi-2.0/swagger-codegen-config.json