using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{

    // created student controller
    public class StudentsController : Controller
    {

        // dbContext field
        private readonly ApplicationDbContext dbContext;

        // constuctor to inject dbContext of type ApplicationDbContext
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // post method to add student data to the database
        [HttpPost]
        // pass viewModel here
        public async Task<IActionResult> Add(AddStudentsViewModel viewModel)
        {
            // create student entity
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            // pass info to EFC to save it
            await dbContext.Students.AddAsync(student);
            // save data to DB
            await dbContext.SaveChangesAsync();


            return View();
        }


        // get method to get list of students
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }

        // get method to go edit page
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);


            return View(student);
        }


        // post method to update and save data in DB
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
    }
}
