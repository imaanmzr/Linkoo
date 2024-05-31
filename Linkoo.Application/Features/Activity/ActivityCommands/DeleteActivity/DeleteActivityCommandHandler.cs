using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public DeleteActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }
        public async Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activityToDelete = _mapper.Map<Domain.Entities.Activity>(request);
            await _activityRepository.DeleteAsync(activityToDelete);
            return Unit.Value;
        }
    }
}