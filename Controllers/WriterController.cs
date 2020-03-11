using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks
{
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var writers = _db.Writers;
            return Ok(writers.Select(w => new { id = w.Id, name = w.Name }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)          
        {
            var writers = _db.Writers;
            if (id> 0)
            {
                return Ok(writers.Where(w => w.Id == id).Select(w => new { id = w.Id, name = w.Name }));
            }
            else
            return Ok(writers.Select(w => new { id = w.Id, name = w.Name }));
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
