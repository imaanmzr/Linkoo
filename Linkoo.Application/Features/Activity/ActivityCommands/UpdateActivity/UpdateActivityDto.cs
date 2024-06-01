using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkoo.Application.Features.ActivityBaseDtos;

namespace Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity
{
    public class UpdateActivityDto : ActivityBaseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}