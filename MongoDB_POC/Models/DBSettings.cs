using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_POC.Models
{
    public class DBSettings : IDBSettings
    {
        public string BooksCollectionName { get ; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set ; }
    }

    public interface IDBSettings
    {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
