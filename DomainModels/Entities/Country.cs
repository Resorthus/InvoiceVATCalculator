using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public Continent Continent { get; set; }

        public double VatPercentage { get; set; }

        public virtual ICollection<TransactionParticipant> Residents{ get; set; }
    }
}
