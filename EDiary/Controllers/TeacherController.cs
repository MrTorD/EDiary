using Domain.Exceptions;

using Infrastructure.Services;
using Infrastructure.Services.Dto;

using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers;

[ApiController]
[Route("teacher")]
public class TeacherController(TeacherService service) : Controller
{
    [HttpGet("{id:guid}")]
    public IActionResult GetTeacher([FromRoute] Guid id)
    {
        try
        {
            return Ok(service.GetTeacher(id));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateTeacher([FromBody] TeacherDto teacher)
    {
        service.CreateTeacher(teacher);

        return Created();
    }
}