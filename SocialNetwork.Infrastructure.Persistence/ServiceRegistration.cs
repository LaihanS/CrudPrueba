using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Infrastructure.Persistence.Repositories;
using SocialNetwork.Core.Application.IRepositories;

namespace SocialNetwork.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void PersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(op => op.UseInMemoryDatabase("databasename"));
            }
            else
            {
                var connectionstring = configuration.GetConnectionString("ConnectionDefault");
                services.AddDbContext<ApplicationContext>(op =>
                {
                    op.UseSqlServer(connectionstring, o => o.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                    op.EnableSensitiveDataLogging();

                });
            }
            #endregion

            #region Injections
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPropertyRepository, PropertyRepository>();

            #endregion
        }
    }
}
