using NLECloudSDK.Model;

namespace QueuingSystem2020.Service.IotService
{
    public class IotGetService : NleService
    {
        public static SensorBaseInfoDTO GetNumber()
        {
            var qry = Sdk.GetSensorInfo(DeviceId, "number_up", Token);
            return qry.ResultObj;
        }
    }
}