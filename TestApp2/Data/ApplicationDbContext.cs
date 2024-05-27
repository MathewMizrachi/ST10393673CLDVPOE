using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10393673CLDVPOE.Models;

namespace ST10393673CLDVPOE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ST10393673CLDVPOE.Models.Image> Image { get; set; } = default!;
        public DbSet<ST10393673CLDVPOE.Models.Product> Product { get; set; } = default!;
        public DbSet<ST10393673CLDVPOE.Models.Category> Category { get; set; } = default!;
    }
}
