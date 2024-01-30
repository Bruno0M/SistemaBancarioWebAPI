using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Map
{
    public class TransacaoMap : IEntityTypeConfiguration<TransacaoModel>
    {
        public void Configure(EntityTypeBuilder<TransacaoModel> builder)
        {
            builder.ToTable("his_transacao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorCompra)
                        .HasColumnName("valor_compra")
                        .HasPrecision(12, 2)
                        .IsRequired();

            builder.Property(x => x.DataCompra)
                        .HasColumnType("date")
                        .HasColumnName("data_compra")
                        .IsRequired();

            builder.Property(x => x.FormaPagamento)
                        .HasColumnName("forma_pagamento")
                        .IsRequired();

            builder.Property(x => x.Situacao)
                        .HasColumnName("situacao");
        }
    }
}
