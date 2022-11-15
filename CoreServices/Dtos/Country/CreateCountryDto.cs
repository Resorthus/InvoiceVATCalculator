using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Country
{
    public class CreateCountryDto
    {
        [Required(ErrorMessage = "Country name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Continent cannot be empty")]
        [EnumDataType(typeof(Continent), ErrorMessage = "Continent value must be a legit continent")]
        public Continent Continent { get; set; }

        [Required(ErrorMessage = "VAT percentage name cannot be empty")]
        [Range(0, 100, ErrorMessage = "Please enter a value between 0 and 100")]
        public double VatPercentage { get; set; }
    }
}
