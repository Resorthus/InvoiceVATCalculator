using CoreServices.Dtos.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dtos.TransactionParticipant
{
    public class TransactionParticipantDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsVATApplicable { get; set; }

        public string Type { get; set; }

        public CountryDto Country { get; set; }
    }
}
