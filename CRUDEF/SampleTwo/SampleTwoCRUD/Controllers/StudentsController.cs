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
        DTOStudent dto = new DTOStudent();
        dto.StudentId = 0;

        return View("StudentCRUD", dto);
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

    [HttpGet]
    public async Task<IActionResult> MoveEdit(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var student = await _context.Students.FindAsync(id);

        if (student is null)
            return NotFound();

        DTOStudent dto = new()
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            MiddleName = student.MiddleName,
            LastName = student.LastName,
            Email = student.Email,
            Phone = student.Phone,
            Address = student.Address
        };

        return View("StudentCRUD", dto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditStudent(int StudentId,
        [Bind("StudentId,Phone,Email,Address,FirstName,MiddleName,LastName")] DTOStudent dto)
    {
        if (StudentId != dto.StudentId)
            return NotFound();

        if (ModelState.IsValid)
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
            _context.Update(students);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(dto);
    }
}
