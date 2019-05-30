#!/bin/sh

pushd "../openapi-2.0/generated/src/Salesforce.MarketingCloud"

dotnet pack Salesforce.MarketingCloud.csproj -p:NuspecFile=Salesforce.MarketingCloud.nuspec --configuration Release --output ../../../../build-artifacts

popd

exit $?