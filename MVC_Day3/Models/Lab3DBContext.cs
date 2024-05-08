using Microsoft.EntityFrameworkCore;

namespace MVC_Day3.Models
{
    public class Lab3DBContext: DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }



        public Lab3DBContext()
        {
            
        }
        public Lab3DBContext(DbContextOptions options):base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVCLab3;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
