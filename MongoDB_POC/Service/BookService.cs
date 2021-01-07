using MongoDB.Driver;
using MongoDB_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB_POC.Service
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BookService(IDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _booksCollection = database.GetCollection<Book>("books");
        }
        public List<Book> Get() =>
            _booksCollection.Find(book => true).ToList();

        public List<Book> GetByQuery(Expression<Func<Book, bool>> predicate)
        {

            var query = _booksCollection.AsQueryable<Book>()
                 .Where(predicate);
            var books = query.ToList();

            //var bookList = _booksCollection.Find(book => true ).Skip(1).Limit(5).ToList();
            return books;
        }
           
        public Book Get(string id) =>
            _booksCollection.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _booksCollection.InsertOne(book);
            return book;
        }

        public ReplaceOneResult Update(string id, Book bookIn)
        {
           var result = _booksCollection.ReplaceOne(book => book.Id == id, bookIn);
            return result;
        }
           

        public void Remove(Book bookIn) =>
            _booksCollection.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _booksCollection.DeleteOne(book => book.Id == id);
    }
}
