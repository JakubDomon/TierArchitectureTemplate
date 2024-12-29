namespace DataAccess.Logic.Entities
{
    internal abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditAt { get; set; }
    }
}
