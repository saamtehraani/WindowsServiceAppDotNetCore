using Microsoft.EntityFrameworkCore;

namespace WorkerService1.DataModel.Model
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
    }
}
