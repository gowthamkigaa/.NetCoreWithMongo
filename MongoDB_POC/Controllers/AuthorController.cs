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
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly IBaseService<Author> _baseService;
        public AuthorController(AuthorService authorService, IBaseService<Author> baseService)
        {
            _authorService = authorService;
            _baseService = baseService;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public dynamic Get()
        {
            //return _baseService.Get("author"); //, x => x.AuthorName == "gowtham"
            return _baseService.Get();

        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: AuthorController/Create
        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            author.Id = ObjectId.GenerateNewId().ToString();
            _authorService.Create(author);
            return author;
        }


        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
