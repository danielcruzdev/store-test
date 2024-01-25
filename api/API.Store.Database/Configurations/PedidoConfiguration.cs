using API.Store.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Store.Database.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ItensPedido)
                   .WithOne(x => x.Pedido)
                   .HasForeignKey(x => x.IdPedido)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
