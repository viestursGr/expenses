using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalExpensesManager.Model.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(receipt => receipt.Id);

            builder.HasOne(receipt => receipt.Shop)
                .WithMany(shop => shop.Receipts)
                .HasForeignKey(receipt => receipt.ShopId)
                .HasPrincipalKey(shop => shop.Id);
        }   
    }
}
