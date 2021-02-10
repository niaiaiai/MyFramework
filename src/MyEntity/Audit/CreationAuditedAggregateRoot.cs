using System;

namespace MyEntity.Audit
{
    public abstract class CreationAuditedAggregateRoot<Key, CreatorKey> : AggregateRoot<Key>, ICreationTime, ICreator<CreatorKey>
    {
        public CreatorKey Creator { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
