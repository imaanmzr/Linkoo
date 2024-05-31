using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkoo.Application.Features.Activity.ActivityQueries.GetActivity
{
    public class GetActivityDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}