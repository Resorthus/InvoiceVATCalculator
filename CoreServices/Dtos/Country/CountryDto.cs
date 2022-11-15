using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Country
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double VatPercentage { get; set; }

        public string Continent { get; set; }
    }
}
