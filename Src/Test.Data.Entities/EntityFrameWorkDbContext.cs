using Microsoft.EntityFrameworkCore;
using Test.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace Test.Data.Entities
{
    [ExcludeFromCodeCoverage]
    public class EntityFrameWorkDbContext: DbContext
    {
        public EntityFrameWorkDbContext(DbContextOptions<EntityFrameWorkDbContext> options)
        : base(options)
            { }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
