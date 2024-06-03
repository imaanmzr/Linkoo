using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities.Common;
using Linkoo.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Linkoo.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly LinkooDbContext _dbContext;
    public GenericRepository(LinkooDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);
    }
}
