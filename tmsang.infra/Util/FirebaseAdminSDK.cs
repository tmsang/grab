using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using tmsang.domain;

namespace tmsang.infra
{
    public class FirebaseAdminSDK: IFirebaseAdminSDK
    {
        public FirebaseAdminSDK()
        {
            var jsonKeyPath = GetAdminSDKKeyJsonFilePath();

            FirebaseApp.Create(new AppOptions()
            {                
                Credential = GoogleCredential.FromFile(jsonKeyPath)
            });
        }

        public async Task<string> SendMessageToFCMTokenAsync(string fcmToken, string title, string body) 
        {
            // This registration token comes from the client FCM SDKs.
            // var registrationToken = "YOUR_REGISTRATION_TOKEN";

            // See documentation on defining a message payload.            
            var message = new Message()
            {
                Notification = new Notification() { 
                    Title = title,
                    Body = body
                },
                Token = fcmToken,
            };            

            // Send a message to the device corresponding to the provided registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            // Response is a message ID string: projects/{project_id}/messages/{message_id}
            // EX: "projects/myproject-b5ae1/messages/0:1500415314455276%31bd1c9631bd1c96"
            return response;
        }

        public async Task<string> SendMessageToTopicAsync(string topic, string title, string body)
        {
            // The topic name can be optionally prefixed with "/topics/".
            // var topic = "highScores";

            // See documentation on defining a message payload.            
            var message = new Message()
            {
                Notification = new Notification() {
                    Title = title,
                    Body = body
                },
                Topic = topic,
            };            

            // Send a message to the devices subscribed to the provided topic.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            return response;
        }

        public async Task<BatchResponse> SendMessageToFCMTokensAsync(List<string> fcmTokens, string title, string body) 
        {
            // Create a list containing up to 500 registration tokens.
            // These registration tokens come from the client FCM SDKs.
            /*
            var registrationTokens = new List<string>()
            {
                "YOUR_REGISTRATION_TOKEN_1",
                // ...
                "YOUR_REGISTRATION_TOKEN_n",
            };
            */

            var message = new MulticastMessage()
            {
                Tokens = fcmTokens,
                Notification = new Notification() { 
                    Title = title,
                    Body = body
                }
            };           

            var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
            // See the BatchResponse reference documentation
            // for the contents of response.
            return response;
        }

        public async Task<string> SendMessageToTopicsAsync(string condition, string title, string body)
        {
            // Define a condition which will send to devices which are subscribed
            // to either the Google stock or the tech industry topics.
            // var condition = "'stock-GOOG' in topics || 'industry-tech' in topics";

            // See documentation on defining a message payload.            
            var message = new Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                },
                Condition = condition,
            };
            
            // Send a message to devices subscribed to the combination of topics
            // specified by the provided condition.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            return response;
        }

        public async Task<BatchResponse> SendBatchAsync(List<Message> messages)
        {
            // Create a list containing up to 500 messages.
            /*
            var messages = new List<Message>()
            {
                new Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Price drop",
                        Body = "5% off all electronics",
                    },
                    Token = registrationToken,
                },
                new Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Price drop",
                        Body = "2% off all books",
                    },
                    Topic = "readers-club",
                },
            };
            */

            var response = await FirebaseMessaging.DefaultInstance.SendAllAsync(messages);
            // See the BatchResponse reference documentation
            // for the contents of response.
            return response;
        }









        //=================================================
        // Private
        //=================================================
        private string GetRootPath() 
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);

            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private string GetAdminSDKKeyJsonFilePath() {
            string workingDirectory = 
                Environment.CurrentDirectory + "/Key/deploy-firebase-id-firebase-adminsdk-etom3-d30c3497bb.json";

            return workingDirectory;
        }
    }
}
