using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Map
{
    public class CartaoMap : IEntityTypeConfiguration<CartaoModel>
    {
        public void Configure(EntityTypeBuilder<CartaoModel> builder)
        {
            builder.ToTable("tb_cartoes");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.NumeroCartao)
                        .HasColumnName("numero_cartao")
                        .HasMaxLength(16)
                        .IsRequired();

            builder.Property(x => x.DataValidadeCartao)
                        .HasColumnType("date")
                        .HasColumnName("data_validade")
                        .IsRequired();

            builder.Property(x => x.Cvv)
                        .HasColumnName("cvv")
                        .HasMaxLength(3)
                        .IsRequired();

        }
    }
}
