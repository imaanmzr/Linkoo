using Linkoo.Application.Features.Activity.ActivityBaseDtos;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public class GetAllActivitiesDto : ActivityBaseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}