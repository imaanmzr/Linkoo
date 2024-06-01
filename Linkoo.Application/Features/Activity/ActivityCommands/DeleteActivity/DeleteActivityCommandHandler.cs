using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Linkoo.Application.Common.Models;
using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public DeleteActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }
        public async Task<Result<Unit>> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activityToDelete = await _activityRepository.GetByIdAsync(request.Id);

            if(activityToDelete == null) return Result<Unit>.Failure("Failed to delete activity");

            activityToDelete = _mapper.Map<Domain.Entities.Activity>(request);

            await _activityRepository.DeleteAsync(activityToDelete);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}