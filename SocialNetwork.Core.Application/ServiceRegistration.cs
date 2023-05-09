using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.IServices;
using SocialNetwork.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application
{
    public static class ServiceRegistration
    {
        public static void ApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            #region Injections
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IPropertyService, PropertyService>();
            #endregion
        }
    }
}
