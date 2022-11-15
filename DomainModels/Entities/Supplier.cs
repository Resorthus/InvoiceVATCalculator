using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Supplier : TransactionParticipant
    {
        
        public Supplier() : base() 
        {
            Type = PersonType.Juridical;
        }

        public Invoice ProduceInvoice(TransactionParticipant client, double transactionPrice)
        {
            var VATMultiplier = 1 + (client.Country.VatPercentage / 100);
            var clientLivesInsideEU = client.Country.Continent == Continent.Europe;
            var participantsAreFromSameCountry = this.CountryId == client.CountryId;
            var finalPrice = 0.0;

            if (!this.IsVATApplicable)
            {
                finalPrice = transactionPrice;
            }

            else
            {
                if (!clientLivesInsideEU)
                {
                    finalPrice = transactionPrice;
                }

                else if (clientLivesInsideEU && !client.IsVATApplicable && !participantsAreFromSameCountry)
                {
                    finalPrice = transactionPrice * VATMultiplier;
                }

                else if (clientLivesInsideEU && client.IsVATApplicable && !participantsAreFromSameCountry)
                {
                    finalPrice = transactionPrice;
                }

                else
                {
                    finalPrice = transactionPrice * VATMultiplier;
                }
            }

            var invoice = new Invoice
            {
                CreatedAt = DateTime.UtcNow,
                Client = client,
                Supplier = this,
                InitialPrice = transactionPrice,
                VATPrice = finalPrice - transactionPrice,
                FinalPrice = finalPrice,           
            };

            return invoice;
        }
    }
}
