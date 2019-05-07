package salesforce.marketingcloud.codegen;

import io.swagger.codegen.SupportingFile;
import io.swagger.codegen.languages.CSharpClientCodegen;

import java.io.File;

public class CsharpGenerator extends CSharpClientCodegen {

    @Override
    public void processOpts() {
        super.processOpts();

        String packageFolder = sourceFolder + File.separator + packageName;
        String authenticatorsPackageDir = packageFolder + File.separator + "Authentication";
        String modelPackageDir = packageFolder + File.separator + this.modelPackage;

        this.supportingFiles.add(new SupportingFile("OAuth2Authenticator.mustache", authenticatorsPackageDir, "OAuth2Authenticator.cs"));
        this.supportingFiles.add(new SupportingFile("AccessTokenRequest.mustache", modelPackageDir, "AccessTokenRequest.cs"));
        this.supportingFiles.add(new SupportingFile("AccessTokenResponse.mustache", modelPackageDir, "AccessTokenResponse.cs"));
    }
}