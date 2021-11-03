using System;

namespace tmsang.domain
{
    public class R_Evaluation: BaseEntity
    {
        public virtual int Id { get; protected set; }

        public virtual Guid OrderId { get; protected set; }

        public virtual int Rating { get; protected set; }
        public virtual string Note { get; protected set; }        
    }
}
