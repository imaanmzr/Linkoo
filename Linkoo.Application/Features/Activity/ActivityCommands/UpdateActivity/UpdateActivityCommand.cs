using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkoo.Application.Common.Models;
using Linkoo.Application.Features.ActivityBaseDtos;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityCommand : UpdateActivityDto, IRequest<Result<Unit>>
    {

    }
}