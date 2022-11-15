using Azure.Core;
using CoreServices.Dtos.Client;
using CoreServices.Dtos.Supplier;
using CoreServices.Dtos.TransactionParticipant;
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
    public class TransactionParticipantService : ITransactionParticipantService
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TransactionParticipantService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TransactionParticipantDto> CreateClient(CreateClientDto request)
        {
            var country = await _repository.GetByIdAsync<Country>(request.CountryId);
            var client = _mapper.MapToClient(request);
            client.Country = country;
            var clientId = await _repository.CreateAsync(client);
            var clientDto = _mapper.MapToTransactionParticipantDto(client);
            clientDto.Id = clientId;
            return clientDto;
        }

        public async Task<TransactionParticipantDto> CreateSupplier(CreateSupplierDto request)
        {
            var country = await _repository.GetByIdAsync<Country>(request.CountryId);
            var supplier = _mapper.MapToSupplier(request);
            supplier.Country = country;
            var supplierId = await _repository.CreateAsync(supplier);
            var supplierDto = _mapper.MapToTransactionParticipantDto(supplier);
            supplierDto.Id = supplierId;
            return supplierDto;
        }

        public async Task<IEnumerable<TransactionParticipantDto>> GetAllClients()
        {
            var clients = await _repository.GetAllAsync<Client>();
            var clientsDto = clients.Select(client => _mapper.MapToTransactionParticipantDto(client));
            return clientsDto;
        }

        public async Task<IEnumerable<TransactionParticipantDto>> GetAllSuppliers()
        {
            var suppliers = await _repository.GetAllAsync<Supplier>();
            var suppliersDto = suppliers.Select(supplier => _mapper.MapToTransactionParticipantDto(supplier));
            return suppliersDto;
        }
    }
}
