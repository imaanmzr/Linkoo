using Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity;
using Linkoo.Application.Features.Activity.ActivityQueries.GetActivity;
using Linkoo.Application.Features.ActivityQueries.GetAllActivities;
using Linkoo.Persistence.DatabaseContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Linkoo.API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<List<GetAllActivitiesDto>> Get()
        {
            var activities = await Mediator.Send(new GetAllActivitiesQuery());

            return activities;
        }

        [HttpGet("{id}")]
        public async Task<GetActivityDto> Get(Guid id)
        {
            return await Mediator.Send(new GetActivityQuery(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateActivityCommand createActivityCommand)
        {
            var response = await Mediator.Send(createActivityCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateActivityCommand updateActivityCommand)
        {
            await Mediator.Send(updateActivityCommand);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteActivityCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
