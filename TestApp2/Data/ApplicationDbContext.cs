using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp2.Models;

namespace TestApp2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TestApp2.Models.Image> Image { get; set; } = default!;
        public DbSet<TestApp2.Models.Product> Product { get; set; } = default!;
        public DbSet<TestApp2.Models.Category> Category { get; set; } = default!;
    }
}
