using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Supplier
{
    public class CreateSupplierDto
    {
        [Required(ErrorMessage = "Client name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "VAT applicability status cannot be empty")]
        public bool IsVATApplicable { get; set; }

        [Required(ErrorMessage = "CountryId cannot be empty")]
        public int CountryId { get; set; }
    }
}
