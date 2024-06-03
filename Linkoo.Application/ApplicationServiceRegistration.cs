using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Linkoo.Application.Features.Activity.ActivityCommands.CreateActivity;
using FluentValidation.AspNetCore;

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
