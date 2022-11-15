using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Invoice : Entity
    {
        public DateTime CreatedAt { get; set; }

        public int ClientId { get; set; }

        public virtual TransactionParticipant Client { get; set; }

        public int SupplierId { get; set; }

        public virtual TransactionParticipant Supplier { get; set; }

        public double InitialPrice { get; set; }

        public double VATPrice { get; set; }

        public double FinalPrice { get; set; }

    }
}
