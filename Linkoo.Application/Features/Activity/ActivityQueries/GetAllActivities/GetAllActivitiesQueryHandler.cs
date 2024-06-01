using AutoMapper;
using Linkoo.Application.Common.Models;
using Linkoo.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Linkoo.Application.Features.ActivityQueries.GetAllActivities
{
    public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, Result<List<GetAllActivitiesDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public GetAllActivitiesQueryHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        public async Task<Result<List<GetAllActivitiesDto>>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
           var activities = await _activityRepository.GetAllAsync();
           var getAllActivitiesDto = _mapper.Map<List<GetAllActivitiesDto>>(activities);
           return Result<List<GetAllActivitiesDto>>.Success(getAllActivitiesDto);
        }
    }
}