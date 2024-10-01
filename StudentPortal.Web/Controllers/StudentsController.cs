using Microsoft.AspNetCore.Mvc;
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
    }
}
