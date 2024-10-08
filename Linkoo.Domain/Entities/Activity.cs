using Linkoo.Domain.Entities.Common;

namespace Linkoo.Domain.Entities
{
    public class Activity : BaseEntity
    {

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}