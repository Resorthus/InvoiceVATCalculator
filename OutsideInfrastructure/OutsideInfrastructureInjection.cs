using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutsideInfrastructure.Data;
using OutsideInfrastructure.Interfaces;
using OutsideInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsideInfrastructure
{
    public static class OutsideInfrastructureInjection
    {
        public static void AddOutsideInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("Database"));
            });

            services.AddScoped(typeof(IRepository), typeof(Repository));

        }
    }
}
