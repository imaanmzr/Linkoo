using AutoMapper;
using Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.DeleteActivity;
using Linkoo.Application.Features.Activity.ActivityCommands.UpdateActivity;
using Linkoo.Application.Features.Activity.ActivityQueries.GetActivity;
using Linkoo.Application.Features.ActivityQueries.GetAllActivities;
using Linkoo.Domain.Entities;

namespace Linkoo.Application.MappingProfiles
{
    public class ActivityMapperProfile : Profile
    {
        public ActivityMapperProfile()
        {
            CreateMap<GetAllActivitiesDto,Activity>().ReverseMap();
            CreateMap<GetActivityDto,Activity>().ReverseMap();
            CreateMap<CreateActivityCommand,Activity>();
            CreateMap<UpdateActivityCommand,Activity>();
            CreateMap<DeleteActivityCommand,Activity>();
        }
        
    }
}