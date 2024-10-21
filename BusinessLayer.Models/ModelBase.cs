namespace BusinessLayer.Models
{
    public abstract class ModelBase
    {
        public required Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
