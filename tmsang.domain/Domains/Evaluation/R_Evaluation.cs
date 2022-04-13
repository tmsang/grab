using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Evaluation: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }              // == OrderId == RequestId
        public virtual float Rating { get; protected set; }
        public virtual string Note { get; protected set; }

        // NO: khong nen co quan he voi bang Root khac - cho phep Id thoi
        public virtual Guid GuestId { get; protected set; }        

        // YES: set relationship to Histories (1-n: 1)
        public virtual IList<B_EvaluationHistory> Histories { get; protected set; }


        // =========================================================
        // METHODS
        // =========================================================
        public static R_Evaluation Create(float rating, string note)
        {
            return Create(Guid.NewGuid(), rating, note);
        }
        public static R_Evaluation Create(Guid id, float rating, string note)
        {
            var evaluation = new R_Evaluation { 
                Id = id,
                Rating = rating,
                Note = note
            };
                
            return evaluation;
        }

        public void AddHistories(E_OrderStatus status, string description)
        {
            var history = B_EvaluationHistory.Create(this.Id, status, DateTime.Now, description);

            if (this.Histories == null) this.Histories = new List<B_EvaluationHistory>();

            this.Histories.Add(history);
        }
    }
}
