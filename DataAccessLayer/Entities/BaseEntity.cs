using DataAccessLayer.Utils.UpdateHelper;

namespace DataAccessLayer.Entities
{
    internal abstract class BaseEntity : IFluentUpdatable
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastEditAt { get; set; }
    }
}
