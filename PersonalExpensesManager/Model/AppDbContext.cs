using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PersonalExpensesManager.Model.Configurations
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
