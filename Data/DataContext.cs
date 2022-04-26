using Microsoft.EntityFrameworkCore;

namespace my_project.Data
{
    public class DataContext:DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Myclass> Myclasses { get; set; }
    }
}
