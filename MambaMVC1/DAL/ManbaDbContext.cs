using MambaMVC1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MambaMVC1.DAL
{
    public class ManbaDbContext : IdentityDbContext
    {
        public ManbaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
