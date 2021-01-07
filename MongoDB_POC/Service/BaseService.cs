using MongoDB.Driver;
using MongoDB_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB_POC.Service
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoDatabase _database;
        public BaseService(IDBSettings settings, string collName)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _collection = _database.GetCollection<T>(collName);
        }
                
        public virtual List<T> GetByQuery(Expression<Func<T, bool>> predicate)
        {            
            var query = _collection.AsQueryable<T>()
                 .Where(predicate);
            var result = query.ToList();
            return result;
        }

        public virtual List<T> Get()
        {
            var query = _collection.AsQueryable<T>();                 
            var result = query.ToList();
            return result;
        }
        public virtual async Task<T> CreateAsync( T data)
        {               
            await _collection.InsertOneAsync(data);
            return data;
        }

        public virtual T Create(T data)
        {
            _collection.InsertOne(data);
            return data;
        }

        public virtual ReplaceOneResult UpdateAsync(FilterDefinition<T> filter, T data)
        {
            var result = _collection.ReplaceOne(filter, data);
            return result;
        }

        public virtual async Task<ReplaceOneResult> Update(FilterDefinition<T> filter, T data)
        {
            var result = await _collection.ReplaceOneAsync(filter, data);
            return result;
        }

        public virtual DeleteResult Remove(FilterDefinition<T> filter)
        {
            var result =  _collection.DeleteOne(filter);
            return result;
        }

        public virtual async Task<DeleteResult> RemoveAsync(FilterDefinition<T> filter)
        {
            var result = await _collection.DeleteOneAsync(filter);
            return result;
        }
    }
}
