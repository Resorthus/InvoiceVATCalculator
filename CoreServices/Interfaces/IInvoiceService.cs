using CoreServices.Dtos.Invoice;
using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateInvoice(CreateInvoiceDto request);

        Task<IEnumerable<InvoiceDto>> GetAllInvoices();
    }
}
