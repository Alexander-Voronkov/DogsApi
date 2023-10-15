namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDogsRepository Dogs { get; }
        Task<int> SaveChangesAsync(CancellationToken cancToken = default);
        Task BeginTransaction(CancellationToken cancToken = default);
        Task CommitTransaction(CancellationToken cancToken = default);
        Task RollbackTransaction(CancellationToken cancToken = default);
    }
}
