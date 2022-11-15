using CoreServices.Interfaces;
using CoreServices.Services;
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

namespace CoreServices
{
    public static class CoreServicesInjection
    {
        public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMapper, EntityMapper>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITransactionParticipantService, TransactionParticipantService>();

        }
    }
}
