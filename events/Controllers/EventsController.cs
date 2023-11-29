using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

       private readonly IDataContext _context;
        public EventsController(IDataContext context)
        {
            _context = context;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
           return Ok(_context.Events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id >= _context.Events.Count)
                return NotFound();
            return Ok( _context.Events.Find(x => x.Id == id));
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event e)
        {
            _context.Events.Add(new Event { Id = e.Id, Title = e.Title, Start = e.Start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event e)
        {
            var ue = _context.Events.Find(e => e.Id == id);
            ue.Title = e.Title;
            ue.Start = e.Start;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var e= _context.Events.Find(x=>x.Id==id);
            _context.Events.Remove(e);

        }
    }
}
