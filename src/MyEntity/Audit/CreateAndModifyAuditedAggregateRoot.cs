using System;

namespace MyEntity.Audit
{
    public class CreateAndModifyAuditedAggregateRoot<Key, CreatorKey, ModifierKey>
        : CreationAuditedAggregateRoot<Key, CreatorKey>, IModifier<ModifierKey>, IModifyTime
    {
        public ModifierKey LastModifier { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
