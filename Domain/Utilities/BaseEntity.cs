namespace Domain.Utilities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }

        public long Id { get; protected set; }
        public DateTime CreationDate { get; private set; }
    }
}
