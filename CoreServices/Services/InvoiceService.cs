using CoreServices.Dtos.Invoice;
using CoreServices.Interfaces;
using DomainModels.Entities;
using OutsideInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> CreateInvoice(CreateInvoiceDto request)
        {
            var client = await _repository.GetByIdAsync<Client>(request.ClientId);
            var supplier = await _repository.GetByIdAsync<Supplier>(request.SupplierId);
            var invoice = supplier.ProduceInvoice(client, request.TransactionPrice);
            var invoiceId = await _repository.CreateAsync(invoice);
            var invoiceDto = _mapper.MapToInvoiceDto(invoice);
            invoiceDto.Id = invoiceId;
            return invoiceDto;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
        {
            var invoices = await _repository.GetAllAsync<Invoice>();
            var invoicesDto = invoices.Select(invoice => _mapper.MapToInvoiceDto(invoice));
            return invoicesDto;
        }
    }
}
