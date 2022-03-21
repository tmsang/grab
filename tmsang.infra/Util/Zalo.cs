using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Text;
using tmsang.domain;
using ZaloCSharpSDK;

namespace tmsang.infra
{
    public class Zalo : IZalo
    {
        private long myAppId = 1605460884855277705;
        private string secret = "iWVSPQeayp865DRjXdL1";
        private string callbackUrl = "https://172.25.129.73:44331";
        private string accessToken = "m15t9cSftdh077iaRoJJVCyUUIPjFTK_br8FR58e-dRnJJ5_7nhRVEHl4t8P0yTx_M4hLpq4X5wVOKfHIXdwV9vrAcLTJj5RvoS0KX9CtWxQR2q19qpp3zKxBG0k0TXSorOBHZq9-431R2jXC1VaG9LV2NbH9z1dh1uCQ4jh_76F13Lu87lnGV43A6CkIVXgx2mGI05ktK_REdbwEsslUk4JSMexUQfu_3zGHZz3jKl65q9iPrk7CuSxDpjtVfi2a1HM4b9oWn7rCsGh46cC5-KqA1WRO8qurGLfAcqmbmsTQcGoste";

        public Zalo()
        {
            // TODO: chuyen -> Singleton nhe!!!!
            /*
            Zalo3rdAppInfo appInfo = new Zalo3rdAppInfo(myAppId, secret, callbackUrl);
            Zalo3rdAppClient appClient = new Zalo3rdAppClient(appInfo);
            string loginUrl = appClient.getLoginUrl();

            var codeVerifier = genCodeVerifier();
            var codeChallenge = genCodeChallenge(codeVerifier);
            string oauthCode = "";
            JObject token = appClient.getAccessToken(oauthCode);
            var access_token = token["access_token"].ToString();            

            //JObject profile = appClient.getProfile(access_token, "id, name, birthday");
            JObject friends = appClient.getFriends(access_token, 0, 100, "id, name, picture");
            JObject sendMessage = appClient.sendMessage(access_token, 3852331461584449386, "Message here....", "");
            */
        }

        public void CallPhone(long userId)
        {
            throw new NotImplementedException();
        }

        private string genCodeVerifier()
        {            
            Random random = new System.Random();
            var code = new byte[32];
            random.NextBytes(code);

            String verifier = System.Convert.ToBase64String(code);
            return verifier;
        }

        private string genCodeChallenge(string codeVerifier)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(codeVerifier);

            SHA256Managed sha = new SHA256Managed();
            sha.TransformFinalBlock(bytes, 0, bytes.Length);

            var shaBytes = sha.Hash;

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                str.AppendFormat("{0:X2}", bytes[i]);

            return str.ToString();
        }        
    }
}
