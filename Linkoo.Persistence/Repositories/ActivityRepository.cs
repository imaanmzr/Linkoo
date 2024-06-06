using Linkoo.Application.Contracts.Persistence.Repositories;
using Linkoo.Domain.Entities;
using Linkoo.Persistence.DatabaseContext;

namespace Linkoo.Persistence.Repositories;

public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
{
    public ActivityRepository(LinkooDbContext _dbContext) : base(_dbContext)
    {
    }

    
}
