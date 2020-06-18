using NLECloudSDK;

namespace QueuingSystem2020.Service.LoginService
{
    public class LoginService : NleService
    {
        public static bool UserLogin(AccountLoginDTO submitData)
        {
            var qry = Sdk.UserLogin(submitData);
            if (!qry.IsSuccess()) return false;
            Token = qry.ResultObj.AccessToken;
            return true;
            /*
             * 如果写成
             *  if (!qry.IsSuccess())
                {
                    Token = qry.ResultObj.AccessToken;
                    return true;
                }
                return false;
                这种风格Rider会提示
             * Invert 'if' statement to reduce nesting
             * 反转if语句以减少嵌套
             */
        }
    }
}