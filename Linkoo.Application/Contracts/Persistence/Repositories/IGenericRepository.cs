using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linkoo.Domain.Entities.Common;

namespace Linkoo.Application.Contracts.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}