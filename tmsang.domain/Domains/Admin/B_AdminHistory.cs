using System;

namespace tmsang.domain
{
    public class B_AdminHistory: BaseEntity
    {
        public virtual int Id { get; protected set; }        
        public virtual E_Status AccountStatusId { get; protected set; }
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }

        // relationship child
        public virtual Guid AccountId { get; protected set; }
        public virtual R_Admin Admin { get; protected set; }

        public static B_AdminHistory Create(E_Status accountStatusId, string description)
        {
            var history = new B_AdminHistory
            {
                AccountStatusId = accountStatusId,
                Description = description,
                HappenDate = DateTime.Now
            };

            return history;
        }

        public static B_AdminHistory CreateForSeed(Guid accountId, int id, E_Status accountStatusId, string description)
        {
            var history = Create(accountStatusId, description);
            history.AccountId = accountId;
            history.Id = id;

            return history;
        }
    }    

}
