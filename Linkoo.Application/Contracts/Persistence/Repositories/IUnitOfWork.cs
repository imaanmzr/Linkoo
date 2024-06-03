using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkoo.Application.Contracts.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}