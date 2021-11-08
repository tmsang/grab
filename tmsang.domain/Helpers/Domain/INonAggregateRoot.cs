namespace tmsang.domain
{
    public interface INonAggregateRoot: IBaseEntity
    {
        // new int Id { get; }
        int Id { get; }
    }
}
