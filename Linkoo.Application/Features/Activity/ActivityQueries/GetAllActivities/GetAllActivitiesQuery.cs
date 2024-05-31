using MediatR;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public record GetAllActivitiesQuery():IRequest<List<GetAllActivitiesDto>>;

}