using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity;
using FluentValidation.AspNetCore;
using Linkoo.Application.Features.ActivityBaseDtos;
using Linkoo.Application.Features.Activity.ActivityBaseValidator;

namespace Linkoo.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateActivityCommandValidator>();
        return services;
    }
}
