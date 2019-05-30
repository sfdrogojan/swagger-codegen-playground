package salesforce.marketingcloud.codegen;

import io.swagger.codegen.SupportingFile;
import io.swagger.codegen.languages.CSharpClientCodegen;

import java.io.File;
import java.util.Calendar;

public class CsharpGenerator extends CSharpClientCodegen {

    @Override
    public void processOpts() {
        packageTitle = "Salesforce MarketingCloud C# SDK";
        packageCompany = "Salesforce";
        packageProductName = "Salesforce Marketing Cloud C# SDK";
        packageCopyright = "Copyright © Salesforce " + Calendar.getInstance().get(Calendar.YEAR);
        packageDescription = "The Salesforce Marketing Cloud C# SDK";
        packageAuthors = "Salesforce";

        super.processOpts();

        String packageFolder = sourceFolder + File.separator + packageName;
        String authenticatorsPackageDir = packageFolder + File.separator + "Authentication";
        String modelPackageDir = packageFolder + File.separator + this.modelPackage;

        this.supportingFiles.add(new SupportingFile("OAuth2Authenticator.mustache", authenticatorsPackageDir, "OAuth2Authenticator.cs"));
        this.supportingFiles.add(new SupportingFile("AccessTokenRequest.mustache", modelPackageDir, "AccessTokenRequest.cs"));
        this.supportingFiles.add(new SupportingFile("AccessTokenResponse.mustache", modelPackageDir, "AccessTokenResponse.cs"));
    }
}