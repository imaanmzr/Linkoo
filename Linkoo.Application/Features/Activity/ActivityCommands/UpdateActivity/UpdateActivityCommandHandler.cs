using AutoMapper;
using Linkoo.Application.Common.Models.Result;
using Linkoo.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public UpdateActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }
        public async Task<Result<Unit>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activityToUpdate = await _activityRepository.GetByIdAsync(request.Id);
            if(activityToUpdate==null) return Result<Unit>.Failure("Failed to update activity");
            activityToUpdate = _mapper.Map<Domain.Entities.Activity>(request);
            await _activityRepository.UpdateAsync(activityToUpdate);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}