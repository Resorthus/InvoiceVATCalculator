using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsideInfrastructure.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>()
            where T : Entity;

        Task<int> CreateAsync<T>(T entity)
            where T : Entity;

        Task<T> GetByIdAsync<T>(int id)
            where T : Entity;
    }
}
