using Linkoo.Application.Common.Models.Result;
using MediatR;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public record GetAllActivitiesQuery():IRequest<Result<List<GetAllActivitiesDto>>>;

}