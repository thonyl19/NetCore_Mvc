using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Mvc.Models
{
    public class DBContext :DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}