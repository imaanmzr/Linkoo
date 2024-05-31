using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
    }
}