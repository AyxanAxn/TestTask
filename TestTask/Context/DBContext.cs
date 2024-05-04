using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Rectangle> Rectangles { get; set; }
    }
}