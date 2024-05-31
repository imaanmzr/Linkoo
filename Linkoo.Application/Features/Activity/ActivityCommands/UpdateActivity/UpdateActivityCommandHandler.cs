using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public UpdateActivityCommandHandler(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }
        public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activityToUpdate = _mapper.Map<Domain.Entities.Activity>(request);
            await _activityRepository.UpdateAsync(activityToUpdate);
            return Unit.Value;
        }
    }
}