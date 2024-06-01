using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkoo.Application.Features.ActivityBaseDtos;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public class GetAllActivitiesDto : ActivityBaseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}