using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Client
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Client name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Client type cannot be empty")]
        [EnumDataType(typeof(PersonType), ErrorMessage = "Client type value must be a legit client type")]
        public PersonType Type { get; set; }

        [Required(ErrorMessage = "VAT applicability status cannot be empty")]
        public bool IsVATApplicable { get; set; }

        [Required(ErrorMessage = "CountryId cannot be empty")]
        public int CountryId { get; set; }
    }
}
