using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Repositories.Domain
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
