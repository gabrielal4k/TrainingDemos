using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    public EventController()
    {
       
    }

    [Route("getme")]
    public IActionResult GetMe()
    {
        return Ok("Hello from EventController!");
    }
}