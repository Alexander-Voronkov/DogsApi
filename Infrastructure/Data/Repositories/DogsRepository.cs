using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private readonly ApplicationDbContext _context;
        public DogsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Add(Dog entity)
        {
            return _context.Dogs.AddAsync(entity).AsTask();
        }

        public Task AddRange(IEnumerable<Dog> entities)
        {
            return _context.Dogs.AddRangeAsync(entities);
        }

        public Task<IQueryable<Dog>> FindMany(Expression<Func<Dog, bool>> predicate)
        {
            return Task.FromResult(_context.Dogs.Where(predicate));
        }

        public Task<Dog?> FindOne(Expression<Func<Dog, bool>> predicate)
        {
            return _context.Dogs.FirstOrDefaultAsync(predicate);
        }

        public Task<Dog?> Get(int id)
        {
            return _context.Dogs.FindAsync(id).AsTask();
        }

        public Task<IQueryable<Dog>> GetAll()
        {
            return Task.FromResult(_context.Dogs.AsQueryable());
        }

        public Task Remove(Dog entity)
        {
            _context.Dogs.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRange(IEnumerable<Dog> entities)
        {
            _context.RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
