using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkoo.Application.Common.Models;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommand : DeleteActivityDto, IRequest<Result<Unit>>
    {
    }
}