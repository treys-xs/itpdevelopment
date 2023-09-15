using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Task.Queries.GetTaskList;
using System.Linq.Expressions;
using System.Threading;

namespace Server.Persistence
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public Repository(TDbContext context)
        {
            _dbContext = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicateSearch) where T : class
        {
            return await _dbContext
                .Set<T>()
                .FirstOrDefaultAsync(predicateSearch);
        }

        public async Task<List<T>> Include<T, P>(Expression<Func<T, P>> predicate) where T : class
        {
            return await _dbContext
                    .Set<T>()
                    .Include(predicate)
                    .ToListAsync();
        }

        public async Task<T> IncludeAndFirstOrDefaultAsync<T, P>(Expression<Func<T, P>> predicate, Expression<Func<T, bool>> predicateSearch) where T : class
        {
            return await _dbContext
                    .Set<T>()
                    .Include(predicate)
                    .FirstOrDefaultAsync(predicateSearch);
        }

        public async Task<List<P>> IncludeWhereMap<T, L, P>(Expression<Func<T, L>> predicate, Expression<Func<T, bool>> predicateSearch, IMapper mapper) where T : class
        {
            return await _dbContext
                .Set<T>()
                .Include(predicate)
                .Where(predicateSearch)
                .ProjectTo<P>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }
        public async Task<List<P>> SelectAllMap<T, P>(IMapper mapper) where T : class
        {
            return await _dbContext
                .Set<T>()
                .ProjectTo<P>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<T> SelectById<T>(long id) where T : class
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _dbContext
                .Set<T>()
                .Update(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> Where<T>(Expression<Func<T, bool>> predicate)  where T : class
        {
            return await _dbContext
               .Set<T>()
               .Where<T>(predicate)
               .ToListAsync();
        }

        public async Task<List<P>> WhereMap<T, P>(Expression<Func<T, bool>> predicate, IMapper mapper) where T : class
        {
            return await _dbContext
               .Set<T>()
               .Where(predicate)
               .ProjectTo<P>(mapper.ConfigurationProvider)
               .ToListAsync();
        }
    }
}
