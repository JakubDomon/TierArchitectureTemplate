namespace DataAccess.DTO
{
    public record EntityDto()
    {
        public Guid Id { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
