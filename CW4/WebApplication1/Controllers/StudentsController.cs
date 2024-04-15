using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent([FromRoute] int id)
    {
        var student = Db.Students.FirstOrDefault(st => st.Id == id);
        if (student is null) return NotFound($"Student with id {id} not found");
        
        Db.Students.Remove(student);
        return NoContent(); // Ok();
    }
}