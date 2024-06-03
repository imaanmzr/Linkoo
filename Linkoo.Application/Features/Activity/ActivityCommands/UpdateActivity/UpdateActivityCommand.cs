using Linkoo.Application.Common.Models.Result;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityCommand : UpdateActivityDto, IRequest<Result<Unit>>
    {

    }
}