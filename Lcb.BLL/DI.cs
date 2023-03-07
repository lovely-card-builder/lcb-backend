using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Lcb.BLL;

public static class DI
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        


        return services;
    }
}