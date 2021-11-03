namespace tmsang.domain
{
    public class R_Area: BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual R_Location Location { get; protected set; }
    }
}
