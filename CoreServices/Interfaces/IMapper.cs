using CoreServices.Dtos.Client;
using CoreServices.Dtos.Country;
using CoreServices.Dtos.Invoice;
using CoreServices.Dtos.Supplier;
using CoreServices.Dtos.TransactionParticipant;
using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IMapper
    {
        CountryDto MapToCountryDto(Country country);

        Country MapToCountry(CreateCountryDto countryDto);

        Client MapToClient(CreateClientDto clientDto);

        Supplier MapToSupplier(CreateSupplierDto supplierDto);

        TransactionParticipantDto MapToTransactionParticipantDto(TransactionParticipant participant);

        InvoiceDto MapToInvoiceDto(Invoice invoice);
    }
}
