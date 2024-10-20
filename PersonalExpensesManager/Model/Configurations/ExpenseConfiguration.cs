using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersonalExpensesManager.Model.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(a => a.Receipt)
                .WithMany(a => a.Expenses)
                .HasForeignKey(a => a.ReceiptId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}
