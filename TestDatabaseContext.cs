using IntegraTestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegraTestTask
{
    public class TestDatabaseContext : DbContext
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options) : base(options) {  }
        public DbSet<Person> People => Set<Person>();
    }
}
