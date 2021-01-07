using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB_POC.Service
{
    public interface IBaseService<T>
    {
        List<T> GetByQuery(Expression<Func<T, bool>> predicate);
        List<T> Get();
        Task<T> CreateAsync(T author);
        T Create(T author);
        ReplaceOneResult UpdateAsync(FilterDefinition<T> filter, T data);
        Task<ReplaceOneResult> Update(FilterDefinition<T> filter, T data);
        DeleteResult Remove(FilterDefinition<T> filter);
        Task<DeleteResult> RemoveAsync(FilterDefinition<T> filter);
    }
}
