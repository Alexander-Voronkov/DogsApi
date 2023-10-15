using Application.Common.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Dogs = new DogsRepository(context);
        }
        public IDogsRepository Dogs { get; }

        public Task BeginTransaction(CancellationToken cancToken)
        {
            _transaction = _context.Database.BeginTransactionAsync(cancToken).Result;
            return Task.CompletedTask;
        }

        public Task CommitTransaction(CancellationToken cancToken)
        {
            return _transaction.CommitAsync(cancToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public Task RollbackTransaction(CancellationToken cancToken)
        {
            return _transaction.RollbackAsync(cancToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancToken)
        {
            return _context.SaveChangesAsync(cancToken);
        }
    }
}
