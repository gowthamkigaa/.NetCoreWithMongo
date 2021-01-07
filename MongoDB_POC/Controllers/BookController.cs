using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB_POC.Models;
using MongoDB_POC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDB_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {

            
            var bookList = _bookService.Get();
            return bookList;

        }

        // GET api/<BookController>/5
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public Book Get(string id)
        {
            return _bookService.Get(id);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            book.Id = ObjectId.GenerateNewId().ToString();
           _bookService.Create(book);
            

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}
