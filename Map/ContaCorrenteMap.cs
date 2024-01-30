using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Map
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrenteModel>
    {
        public void Configure(EntityTypeBuilder<ContaCorrenteModel> builder)
        {
            builder.ToTable("tb_conta_corrente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroContaCorrente)
                .HasColumnName("numero_conta")
                .HasMaxLength(9)
                .IsRequired();

        }
    }
}
