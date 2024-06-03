using Linkoo.Application.Common.Models.Result;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityQueries.GetActivity
{
    public record GetActivityQuery(Guid Id):IRequest<Result<GetActivityDto>>;
}