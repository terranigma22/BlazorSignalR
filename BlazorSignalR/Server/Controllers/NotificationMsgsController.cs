using BlazorSignalR.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorSignalR.Server.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationMsgsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public NotificationMsgsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<NotificationMsgsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationMsg>>> Get()
        {
            return await context.NotificationMsgs.ToListAsync();
        }

        // GET api/<NotificationMsgsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotificationMsgsController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] string value)
        {
            NotificationMsg msg = new NotificationMsg()
            {
                Message = value
            };
            context.Add(msg);
            await context.SaveChangesAsync();
            return msg.Id;
        }

        // PUT api/<NotificationMsgsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotificationMsgsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            context.RemoveRange(context.NotificationMsgs);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
