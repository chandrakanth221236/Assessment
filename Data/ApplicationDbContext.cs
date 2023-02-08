using Chandrakanth_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Chandrakanth_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
    }
}