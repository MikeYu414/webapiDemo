using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IRASApiController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public IRASApiController(TodoContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return Ok("get");
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            var client = _httpClientFactory.CreateClient("ExternalApi");

            var content = new StringContent(JsonConvert.SerializeObject(todoItem.Content), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(todoItem.Url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(responseContent);
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            //_context.TodoItems.Add(todoItem);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }
    }
}
