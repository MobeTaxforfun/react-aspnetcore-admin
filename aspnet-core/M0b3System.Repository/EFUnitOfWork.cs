using M0b3System.Infrastructure.Contract;
using System.Data.Common;

namespace M0b3System.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbTransaction Begin()
        {
            throw new NotImplementedException();
        }

        public Task<DbTransaction> BeginAsync()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}