using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public interface IStorage
    {
        string RootFolder { get; }
        void SmsSet(string email, string value);
        string SmsGetCode(string phone);
    }

    public class SmsVerification
    {
        public DateTime Expired { get; set; }
        public string Value { get; set; }
    }

    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        static Singleton()
        {
        }
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public string RootPath { get; set; }
        public string UrlApi { get; set; }
        public string GoogleApiKey { get; set; }

        public Dictionary<string, SmsVerification> SmsStorage { get; set; } = new Dictionary<string, SmsVerification>();
    }
}
