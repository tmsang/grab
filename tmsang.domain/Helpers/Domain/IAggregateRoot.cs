using System;

namespace tmsang.domain
{
    public interface IAggregateRoot: IBaseEntity
    {
        // new Guid Id { get; }
        Guid Id { get; }
    }
}
