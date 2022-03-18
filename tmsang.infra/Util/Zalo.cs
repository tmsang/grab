using Newtonsoft.Json.Linq;
using System;
using tmsang.domain;
using ZaloCSharpSDK;

namespace tmsang.infra
{
    public class Zalo : IZalo
    {
        private long myAppId = 1605460884855277705;
        private string secret = "iWVSPQeayp865DRjXdL1";
        private string callbackUrl = "https://172.25.129.73:44331";
        private string accessToken = "5r_wS74xrXGNKlPoUJRR4XXGz71xBwbOH1lYE5i7oI1u6Bu_5WFhB1G2fpKK6VSLCtY3SW18tqe6Ue12Oc3LVLb-jHbzNPWpQ3dE4reza0rkNEqm2Mp193vBx4GvLiHo9pUkUYOSvryHTRP0AqlX94rydJjKIR85CrcO3WvWppWFSeWdD6_I4oPkYni4RTzz0N-kVWHeyKabIwDfFMhgSYLsa556HVbGSdYiK79kuM5XV9PHKLhuHM9gf4L-KFfDHq2FRbL9y7vwSzbwM1QLObuNj6T6CFPYGp6ANdL6Lb4OKd8WqnG";

        public Zalo()
        {
            Zalo3rdAppInfo appInfo = new Zalo3rdAppInfo(myAppId, secret, callbackUrl);
            Zalo3rdAppClient appClient = new Zalo3rdAppClient(appInfo);
            string loginUrl = appClient.getLoginUrl();
                                    
            JObject token = appClient.getAccessToken(accessToken);
            var access_token = token["access_token"].ToString();

            //JObject profile = appClient.getProfile(access_token, "id, name, birthday");
            JObject friends = appClient.getFriends(access_token, 0, 100, "id, name, picture");
            JObject sendMessage = appClient.sendMessage(access_token, 3852331461584449386, "Message here....", "");

        }

        public void CallPhone(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
