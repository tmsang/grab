using System;

namespace tmsang.domain
{
    public class B_DriverHistory: BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual Guid AccountId { get; protected set; }
        public virtual int AccountStatusId { get; protected set; }
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }
    }
}
