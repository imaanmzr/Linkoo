using AutoMapper;
using Linkoo.Application.Common.Models.Result;
using Linkoo.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activityToDelete = await _activityRepository.GetByIdAsync(request.Id);

            if(activityToDelete == null) return Result<Unit>.Failure("Failed to delete activity");

            activityToDelete = _mapper.Map<Domain.Entities.Activity>(request);

            await _activityRepository.DeleteAsync(activityToDelete);
            await _unitOfWork.CommitChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}