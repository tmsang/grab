using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Response: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }        

        public virtual DateTime Start { get; protected set; }
        public virtual DateTime End { get; protected set; }

        public virtual double Fee { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan de luu tru
        public virtual double Tax { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan vao luu tru                

        // NO: khong nen co quan he voi bang Root khac - cho phep Id thoi
        public virtual Guid DriverId { get; protected set; }        

        // relationship (1-n: 1)
        public virtual IList<B_ResponseHistory> Histories { get; protected set; }

        public static R_Response Create(Guid driverId, double fee, double tax) {
            return Create(Guid.NewGuid(), driverId, fee, tax);
        }

        public static R_Response Create(Guid id, Guid driverId, double fee, double tax) {
            var response = new R_Response {
                Id = id,

                Fee = fee,
                Tax = tax,
                
                DriverId = driverId
            };

            return response;
        }

        public void AddHistories(E_OrderStatus status, string description)
        {
            var history = B_ResponseHistory.Create(this.Id, status, DateTime.Now, description);

            if (this.Histories == null) this.Histories = new List<B_ResponseHistory>();

            this.Histories.Add(history);
        }

        public void UpdateTimeStart(DateTime start)
        {
            this.Start = start;
        }

        public void UpdateTimeEnd(DateTime end)
        {
            this.End = end;
        }        
    }
}
