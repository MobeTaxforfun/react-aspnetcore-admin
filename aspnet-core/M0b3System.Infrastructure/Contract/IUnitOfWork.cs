using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0b3System.Infrastructure.Contract
{
    public interface IUnitOfWork
    {
        DbTransaction Begin();

        Task<DbTransaction> BeginAsync();

        void Commit();

        Task CommitAsync();

        void Rollback();

        Task RollbackAsync();
    }
}
