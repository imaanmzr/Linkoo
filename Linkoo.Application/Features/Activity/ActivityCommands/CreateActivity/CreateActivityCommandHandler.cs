using AutoMapper;
using Linkoo.Application.Common.Models;
using Linkoo.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public CreateActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        public async Task<Result<Guid>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _mapper.Map<Domain.Entities.Activity>(request);
            await _activityRepository.CreateAsync(activity);
            return Result<Guid>.Success(activity.Id);
        }
    }
}