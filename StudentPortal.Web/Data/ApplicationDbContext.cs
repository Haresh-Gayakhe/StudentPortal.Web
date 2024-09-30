using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{

    // this inherits DbContext from Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {

        // create constructor and pass DbContextOptions of type ApplicationDbContext and named it as options and also pass to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // use student entity here as property which will DbSet represent as collection of type student and table name as students
        public DbSet<Student> Students { get; set; }

    }
}
