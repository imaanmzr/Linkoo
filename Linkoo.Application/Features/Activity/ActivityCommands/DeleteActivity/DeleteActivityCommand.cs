using Linkoo.Application.Common.Models.Result;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommand : DeleteActivityDto, IRequest<Result<Unit>>
    {
    }
}