using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tmsang.domain;

namespace tmsang.infra
{
    public class Storage: IStorage
    {
        public string RootFolder { 
            get {
                return Singleton.Instance.RootPath;
            } 
        }
        

        public Storage()
        {
            
        }

        public void SmsSet(string phone, string value) {
            // reset key if expired
            AutoResetKey();

            // reset key = email het
            Singleton.Instance.SmsStorage.Remove(phone);

            Singleton.Instance.SmsStorage.Add(phone, new SmsVerification {
                Value = value,
                Expired = DateTime.Now
            });

            // set event to send SMS here!!!! Event + Handle
            DomainEvents.Raise<R_AccountSmsVerificationEvent>(new R_AccountSmsVerificationEvent { Phone = phone, Code = value });

        }

        public string SmsGetCode(string phone) {
            var code = Singleton.Instance.SmsStorage.Where(p => p.Key == phone).Select(p => p.Value.Value).FirstOrDefault();
            return code;
        }

        private void AutoResetKey() {
            var items = Singleton.Instance.SmsStorage.Where(p => p.Value.Expired.AddHours(1) >= DateTime.Now).Select(p => p.Key).ToList();
            items.ForEach(key => {
                Singleton.Instance.SmsStorage.Remove(key);
            });
        }

    }

}
