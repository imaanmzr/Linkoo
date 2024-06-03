using Linkoo.Application.Features.Activity.ActivityBaseDtos;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityDto : ActivityBaseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}