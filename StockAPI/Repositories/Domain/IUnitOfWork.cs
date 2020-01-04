using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repositories.Domain
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
