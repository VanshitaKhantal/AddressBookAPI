using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Entity; // Import your entity namespace

namespace AddressBookTests.TestSetup 
{
    public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

    public DbSet<AddressBookEntry> AddressBookEntries { get; set; } // Adjust based on your project
    public DbSet<UserEntity> Users { get; set; } // Add other entities
    }

}
