using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Contracts.Interface.Service;

namespace TodoApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    IEventService _eventService;
    public EventController(IEventService service)
    {
       _eventService = service;
    }

    [Route("getme")]
    public IActionResult GetMe()
    {
        return Ok("Hello from EventController!");
    }

    [HttpGet, Route("get/list")]
    public IActionResult GetEvents()
    {
        var dtos = _eventService.GetDTOEvents();

        if(dtos.Count is 0)
            return NoContent();

        return Ok(dtos);
    }

    [HttpGet, Route("get/list/eventid/{id}")]
    public IActionResult GetEvent(int id)
    {
        var dto = _eventService.GetDTOEvent(id);

        if (dto is null)
            return NotFound();

        return Ok(dto);
    }
}