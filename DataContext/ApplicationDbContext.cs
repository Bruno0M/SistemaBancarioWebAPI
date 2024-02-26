using Microsoft.EntityFrameworkCore;
using SistemaBancarioWebAPI.Map;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }


        public DbSet<CartaoModel> Cartoes { get; set; }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<ContaCorrenteModel> ContasCorrentes { get; set; }
        public DbSet<SaldoModel> Saldos {  get; set; }
        public DbSet<TransacaoModel> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartaoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new ContaCorrenteMap());
            modelBuilder.ApplyConfiguration(new SaldoMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

