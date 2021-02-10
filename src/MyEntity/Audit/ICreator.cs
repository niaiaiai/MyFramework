namespace MyEntity.Audit
{
    public interface ICreator<Key>
    {
        Key Creator { get; set; }
    }
}
