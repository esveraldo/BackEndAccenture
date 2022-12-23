using Log.Accenture.Domain.Core;

namespace Log.Accenture.Domain.Entities
{
    public class LogSystem : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }
}
