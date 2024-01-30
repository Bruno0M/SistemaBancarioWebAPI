using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Map
{
    public class SaldoMap : IEntityTypeConfiguration<SaldoModel>
    {
        public void Configure(EntityTypeBuilder<SaldoModel> builder)
        {
            builder.ToTable("tb_saldo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SaldoConta)
                .HasColumnName("saldo_conta")
                .HasPrecision(12, 2)
                .IsRequired();
        }
    }
}
