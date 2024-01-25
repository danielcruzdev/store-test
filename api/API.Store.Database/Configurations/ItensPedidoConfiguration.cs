using API.Store.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Store.Database.Configurations
{
    public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Produto)
                   .WithOne()
                   .HasForeignKey<ItemPedido>(x => x.IdProduto)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
