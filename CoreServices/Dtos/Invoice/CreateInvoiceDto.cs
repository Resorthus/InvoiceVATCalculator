using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Invoice
{
    public class CreateInvoiceDto
    {
        [Required(ErrorMessage = "ClientId can not be null")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "SupplierId can not be null")]
        public int SupplierId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public double TransactionPrice { get; set; }
    }
}
