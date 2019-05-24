pushd "..\openapi-2.0\generated\src\Salesforce.MarketingCloud"

..\..\..\..\build-artifacts\nuget.exe pack Salesforce.MarketingCloud.nuspec -Properties Configuration=Release -OutputDirectory "..\..\..\..\build-artifacts"

popd
