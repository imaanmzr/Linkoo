using Linkoo.Application.Common.Models.Result;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity
{
    public class CreateActivityCommand : CreateActivityDto, IRequest<Result<Guid>>
    {

    }
}