using MongoDB.Driver;
using MongoDB_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB_POC.Service
{
    public class AuthorService : BaseService<Author>
    {
        private readonly IMongoCollection<Author> _authorCollection;
        public AuthorService(IDBSettings settings): base(settings, "author")
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _authorCollection = database.GetCollection<Author>("author");
        }
       

        public Author Get(string id) =>
            _authorCollection.Find<Author>(author => author.Id == id).FirstOrDefault();

              
    }
}
