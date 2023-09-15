using AutoMapper;
using System.Linq.Expressions;

namespace Server.Application.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> SelectAll<T>() where T : class;
        Task<List<P>> SelectAllMap<T, P>(IMapper mapper) where T : class;
        Task<List<T>> Where<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<List<P>> WhereMap<T, P>(Expression<Func<T, bool>> predicate, IMapper mapper) where T : class;
        Task<T> SelectById<T>(long id) where T : class;
        Task<List<T>> Include<T, P>(Expression<Func<T, P>> predicate) where T : class;
        Task<List<P>> IncludeWhereMap<T, L, P>(Expression<Func<T, L>> predicate, Expression<Func<T, bool>> predicateSearch, IMapper mapper) where T : class;

        Task<T> IncludeAndFirstOrDefaultAsync<T, P>(Expression<Func<T, P>> predicate, Expression<Func<T, bool>> predicateSearch) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicateSearch) where T : class;
        System.Threading.Tasks.Task CreateAsync<T>(T entity) where T : class;
        System.Threading.Tasks.Task UpdateAsync<T>(T entity) where T : class;
        System.Threading.Tasks.Task DeleteAsync<T>(T entity) where T : class;
    }
}
