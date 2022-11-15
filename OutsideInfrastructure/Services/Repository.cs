using DomainModels.Entities;
using DomainModels.Exceptions;
using Microsoft.EntityFrameworkCore;
using OutsideInfrastructure.Data;
using OutsideInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsideInfrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            where T : Entity
        {
            return await _context.Set<T>().AsQueryable().ToListAsync();
        }

        public async Task<int> CreateAsync<T>(T entity)
            where T : Entity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<T> GetByIdAsync<T>(int id)
            where T : Entity
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new DbEntityNotFoundException($"{typeof(T).Name} entry {id} not found");
            }

            return entity;
        }
    }
}
