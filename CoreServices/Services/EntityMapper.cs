using CoreServices.Dtos.Client;
using CoreServices.Dtos.Country;
using CoreServices.Dtos.Invoice;
using CoreServices.Dtos.Supplier;
using CoreServices.Dtos.TransactionParticipant;
using CoreServices.Interfaces;
using DomainModels.Entities;

namespace CoreServices.Services
{
    public class EntityMapper : IMapper
    {
        public Client MapToClient(CreateClientDto clientDto)
        {
            var client = new Client
            {
                Name = clientDto.Name,
                IsVATApplicable = clientDto.IsVATApplicable,
                Type = clientDto.Type,
                CountryId = clientDto.CountryId,
            };

            return client;
        }

        public Country MapToCountry(CreateCountryDto countryDto)
        {
            var country = new Country
            {
                Name = countryDto.Name,
                Continent = countryDto.Continent,
                VatPercentage = countryDto.VatPercentage,
            };

            return country;
        }

        public CountryDto MapToCountryDto(Country country)
        {
            var countryDto = new CountryDto
            {   Id = country.Id,
                Name = country.Name,
                Continent = Enum.GetName(country.Continent),
                VatPercentage = country.VatPercentage,
            };

            return countryDto;
        }

        public InvoiceDto MapToInvoiceDto(Invoice invoice)
        {
            var invoiceDto = new InvoiceDto
            {
                Id = invoice.Id,
                Client = MapToTransactionParticipantDto(invoice.Client),
                Supplier = MapToTransactionParticipantDto(invoice.Supplier),
                CreatedAt = invoice.CreatedAt.AddTicks(-(invoice.CreatedAt.Ticks % 10000000)),
                InitialPrice = invoice.InitialPrice,
                VATPrice = invoice.VATPrice,
                FinalPrice = invoice.FinalPrice,
            };

            return invoiceDto;
        }

        public Supplier MapToSupplier(CreateSupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                Name = supplierDto.Name,
                IsVATApplicable = supplierDto.IsVATApplicable,
                CountryId = supplierDto.CountryId,
            };

            return supplier;
        }

        public TransactionParticipantDto MapToTransactionParticipantDto(TransactionParticipant participant)
        {
            var participantDto = new TransactionParticipantDto
            {
                Id = participant.Id,
                Name = participant.Name,
                IsVATApplicable = participant.IsVATApplicable,
                Type = Enum.GetName(participant.Type),
                Country = MapToCountryDto(participant.Country),
            };

            return participantDto;
        }
    }
}
