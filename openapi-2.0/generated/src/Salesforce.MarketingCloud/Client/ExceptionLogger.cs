using System.Runtime.CompilerServices;

namespace Salesforce.MarketingCloud.Client
{
    public class ExceptionLogger
    {
        public static log4net.ILog GetLogger([CallerFilePath] string fileName = "")
        {
            return log4net.LogManager.GetLogger(fileName);
        }
    }
}