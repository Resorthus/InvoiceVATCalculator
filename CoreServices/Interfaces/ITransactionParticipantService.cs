using CoreServices.Dtos.Client;
using CoreServices.Dtos.Supplier;
using CoreServices.Dtos.TransactionParticipant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface ITransactionParticipantService
    {
        Task<TransactionParticipantDto> CreateSupplier(CreateSupplierDto createSupplierDto);

        Task<TransactionParticipantDto> CreateClient(CreateClientDto createClientDto);

        Task<IEnumerable<TransactionParticipantDto>> GetAllClients();

        Task<IEnumerable<TransactionParticipantDto>> GetAllSuppliers();

    }
}
