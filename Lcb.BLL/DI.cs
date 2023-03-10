using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Lcb.BLL;

public static class DI
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(executingAssembly);

        services.AddAutoMapper(executingAssembly);
        

        services.AddValidatorsFromAssembly(executingAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}