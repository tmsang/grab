using System;

namespace tmsang.domain
{
    public class B_GuestPolicy: BaseEntity
    {
        public virtual int Id { get; protected set; }        
        public virtual DateTime From { get; protected set; }
        public virtual DateTime To { get; protected set; }
        public virtual E_Status Status { get; protected set; }

        // relationship child
        public virtual Guid AccountId { get; protected set; }
        public virtual R_Guest Guest { get; protected set; }
    }
}
