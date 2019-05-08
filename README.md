# This a POC of a C# API client built with Swagger Codegen.

## Getting started with the custom C# generator

Before the first execution of the custom generator, you should run the following scripts:

1. Execute the script to build the custom C# generator: `scripts\build-custom-csharp-generator.bat`
2. Execute the script to generate the C# API client: `scripts\generate-csharp-api-client.bat`

```
cd scripts
build-custom-csharp-generator.bat
generate-csharp-api-client.bat
```

## Customizing the custom C# generator

The mustache templates can be found in `generators\csharp\src\main\resources\csharp`. They are part of a Maven project for the custom generator that can be found in `generators\csharp`.

You can customize the mustache templates and the supporting class `generators\csharp\src\main\java\io\swagger\codegen\CsharpGenerator.java` for new mustache templates, but you need to build the Maven project by executing the `scripts\build-custom-csharp-generator.bat` script, or by running `mvn clean package` in the root folder of the Maven project.

## Running the Swagger Codegen CLI

To run the Swagger Codegen CLI and generate the C# API client from the Open API spec, run the `scripts\generate-csharp-api-client.bat` script.

## Running the Integration tests

Create a class named ApiTests in the Salesforce.MarketingCloud.Test project. 
It should have the same content as the ApiTests.cs.template file.

To run the tests, enter valid values for the fields: authBasePath, clientId, clientSecret, accountId.