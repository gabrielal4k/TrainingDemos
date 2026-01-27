using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleCrud.Contracts.DTO;
using SampleCrud.Contracts.Entities;
using SampleTwoCRUD.EntityFramework.Data;
using System.Threading.Tasks;

namespace SampleTwoCRUD.Controllers;

public class StudentsController : Controller
{

    private readonly ApplicationContext _context;

    public StudentsController(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        var dtos = await _context.Students.ToListAsync();
        return View(dtos);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("StudentCRUD");
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(
        [Bind("Phone,Email,Address,FirstName,MiddleName,LastName")] DTOStudent dto)
    {
        if(ModelState.IsValid)
        {
            Students students = new Students
            {
                StudentId = dto.StudentId,
                FirstName = dto.FirstName!,
                MiddleName = dto.MiddleName!,
                LastName = dto.LastName!,
                Email = dto.Email!,
                Phone = dto.Phone,
                Address = dto.Address
            };
            _context.Add(students);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(dto);
    }
}
