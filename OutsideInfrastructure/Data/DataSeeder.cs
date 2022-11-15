using DomainModels.Entities;
using DomainModels.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsideInfrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedData(this IServiceProvider provider)
        {
            var countries = new List<Country>()
            {
                new Country { Name = "Lithuania", VatPercentage = 21, Continent = Continent.Europe },
                new Country { Name = "Bulgaria", VatPercentage = 20, Continent = Continent.Europe },
                new Country { Name = "Japan", VatPercentage = 5, Continent = Continent.Asia },
                new Country { Name = "Canada", VatPercentage = 5, Continent = Continent.NorthAmerica },
                new Country { Name = "Egypt", VatPercentage = 10, Continent = Continent.Africa },
                new Country { Name = "New Zealand", VatPercentage = 15, Continent = Continent.Australia }
            };

            var context = provider.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
            await AddCountries(context, countries);
            await AddClients(context, countries);
            await AddSuppliers(context, countries);
            
        }

        private static async Task AddCountries(DatabaseContext context, List<Country> countries)
        {
            if (context.Countries.Any())
            {
                return;
            }

            countries.ForEach(country => context.Countries.Add(country));
            await context.SaveChangesAsync();
        }

        private static async Task AddClients(DatabaseContext context, List<Country> countries)
        {
            if (context.Clients.Any())
            {
                return;
            }

            context.Clients.Add(new Client { Name = "Antanas Smetona", IsVATApplicable = true, Type = PersonType.Physical, Country = countries[0] });
            context.Clients.Add(new Client { Name = "UAB Kauno Grūdai", IsVATApplicable = false, Type = PersonType.Juridical, Country = countries[1] });
            context.Clients.Add(new Client { Name = "Kazys Binkis", IsVATApplicable = true, Type = PersonType.Physical, Country = countries[2] });
            context.Clients.Add(new Client { Name = "UAB Neptūnas", IsVATApplicable = false, Type = PersonType.Juridical, Country = countries[3] });
            context.Clients.Add(new Client { Name = "Vladimiras Putinas", IsVATApplicable = true, Type = PersonType.Physical, Country = countries[4] });
            context.Clients.Add(new Client { Name = "UAB Topo Centras", IsVATApplicable = false, Type = PersonType.Juridical, Country = countries[5] });

            await context.SaveChangesAsync();
        }

        private static async Task AddSuppliers(DatabaseContext context, List<Country> countries)
        {
            if (context.Suppliers.Any())
            {
                return;
            }

            context.Suppliers.Add(new Supplier { Name = "UAB Inmedica", IsVATApplicable = true, Country = countries[0] });
            context.Suppliers.Add(new Supplier { Name = "UAB Starbucks", IsVATApplicable = true, Country = countries[1] });
            context.Suppliers.Add(new Supplier { Name = "UAB MCDonalds", IsVATApplicable = false, Country = countries[2] });
            context.Suppliers.Add(new Supplier { Name = "UAB Hesburger", IsVATApplicable = false, Country = countries[3] });
            context.Suppliers.Add(new Supplier { Name = "UAB Forum Cinemas", IsVATApplicable = true, Country = countries[4] });
            context.Suppliers.Add(new Supplier { Name = "UAB Mega", IsVATApplicable = true, Country = countries[5] });

            await context.SaveChangesAsync();
        }
    }
}
