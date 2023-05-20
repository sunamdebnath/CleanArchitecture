using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());    //Registers the Automapper into the current Assembly for DI
            services.AddMediatR(Assembly.GetExecutingAssembly());       //Registers the MediatR into the current Assembly for DI

            return services;
        }
    }
}
