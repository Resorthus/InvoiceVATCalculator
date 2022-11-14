using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public abstract class TransactionParticipant : Entity
    {
        public string Name { get; set; }

        public PersonType Type { get; set; }

        public bool IsVATApplicable { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Invoice> 

        public TransactionParticipant() { }
    }
}
