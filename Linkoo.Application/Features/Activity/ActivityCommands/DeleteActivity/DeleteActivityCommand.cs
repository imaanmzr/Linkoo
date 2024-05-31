using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity
{
    public class DeleteActivityCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}