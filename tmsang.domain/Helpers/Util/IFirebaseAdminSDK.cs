using FirebaseAdmin.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.domain
{
    public interface IFirebaseAdminSDK
    {
        Task<string> SendMessageToFCMTokenAsync(string fcmToken, string title, string body);
        Task<string> SendMessageToTopicAsync(string topic, string title, string body);
        Task<BatchResponse> SendMessageToFCMTokensAsync(List<string> fcmTokens, string title, string body);
        Task<string> SendMessageToTopicsAsync(string condition, string title, string body);
        Task<BatchResponse> SendBatchAsync(List<Message> messages);
    }
}
