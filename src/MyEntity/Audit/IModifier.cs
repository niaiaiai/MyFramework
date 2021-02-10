namespace MyEntity.Audit
{
    public interface IModifier<Key>
    {
        Key LastModifier { get; set; }
    }
}
