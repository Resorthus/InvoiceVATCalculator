using CoreServices.Dtos.TransactionParticipant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.Invoice
{
    public class InvoiceDto
    {
        public TransactionParticipantDto Client { get; set; }

        public TransactionParticipantDto Supplier { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public double InitialPrice { get; set; }

        public double VATPrice { get; set; }

        public double FinalPrice { get; set; }

    }
}
