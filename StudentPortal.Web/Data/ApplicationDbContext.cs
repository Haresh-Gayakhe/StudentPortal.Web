using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Web.Data
{

    // this inherits DbContext from Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {

        // create constructor and pass DbContextOptions of type ApplicationDbContext and named it as options and also pass to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
