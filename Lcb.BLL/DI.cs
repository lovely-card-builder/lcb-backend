using System.Reflection;
using Lcb.BLL.Services;
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