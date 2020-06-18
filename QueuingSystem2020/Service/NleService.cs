using NLECloudSDK;

namespace QueuingSystem2020.Service
{
    public class NleService
    {
        //新大陆云平台SDK
        protected static readonly NLECloudAPI Sdk = new NLECloudAPI(ApplicationSettings.Get("ApiHost"));
        
        //从配置文件中读取设备ID
        protected static readonly int DeviceId = int.Parse(ApplicationSettings.Get("DeviceId"));
        
        //登录后返回的Token
        protected static string Token { get; set; }
    }
}