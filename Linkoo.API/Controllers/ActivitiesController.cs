using Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity;
using Linkoo.Application.Features.Activity.ActivityQueries.GetActivity;
using Linkoo.Application.Features.ActivityQueries.GetAllActivities;
using Microsoft.AspNetCore.Mvc;


namespace Linkoo.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResults(await Mediator!.Send(new GetAllActivitiesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return HandleResults(await Mediator!.Send(new GetActivityQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateActivityCommand createActivityCommand)
        {
            return HandleResults(await Mediator!.Send(createActivityCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateActivityCommand updateActivityCommand)
        {
            return HandleResults(await Mediator!.Send(updateActivityCommand));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResults(await Mediator!.Send(new DeleteActivityCommand { Id = id }));
        }
    }
}
