using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public class GetAllActivitiesDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}