using System;

namespace tmsang.domain
{
    public abstract class MasterEntity
    {
        public virtual int Id { get; protected set; }
        public virtual int Name { get; protected set; }
        public virtual E_Mode Mode { get; protected set; } = E_Mode.None;
        public virtual DateTime? From { get; protected set; } = null;
        public virtual DateTime? To { get; protected set; } = null;
        public virtual DateTime? ChangedDate { get; protected set; } = DateTime.Now;
    }
}
