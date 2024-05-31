using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Linkoo.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityQueries.GetActivity
{
    public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, GetActivityDto>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public GetActivityQueryHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }
        public async Task<GetActivityDto> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(request.Id);
            var activityDto = _mapper.Map<GetActivityDto>(activity);
            return activityDto;
        }
    }
}