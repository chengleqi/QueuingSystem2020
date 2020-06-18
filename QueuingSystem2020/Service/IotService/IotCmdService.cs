namespace QueuingSystem2020.Service.IotService
{
    public class IotCmdService : NleService
    {
        public static void StartTake()
        {
            var qry = Sdk.Cmds(DeviceId, "bool_work", 1, Token);
        }

        public static void PauseTake()
        {
            var qry = Sdk.Cmds(DeviceId, "bool_work", 0, Token);
        }

        public static void CallNumber()
        {
            var qry = Sdk.Cmds(DeviceId, "number_down", 3, Token);
        }

        public static void SendMessage(string content)
        {
            var qry = Sdk.Cmds(DeviceId, "string_play", content, Token);
        }
    }
}