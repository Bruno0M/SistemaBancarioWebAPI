using SistemaBancarioWebAPI.Models;
using System.Globalization;

namespace SistemaBancarioWebAPI.Dtos
{
    public class CriarPessoaDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroContaCorrente { get; set; }
        public int Cvv { get; set; }
        public decimal SaldoContaCorrente { get; set; }
        public DateTime DataValidadeCartao { get; set; }

        public PessoaModel ToEntity()
        {
            return new PessoaModel
            {
                Id = Id,
                Nome = Nome,
                Cpf = Cpf,
                Cartao = new CartaoModel()
                {
                    NumeroCartao = NumeroCartao,
                    Cvv = Cvv,
                    DataValidadeCartao = DataValidadeCartao,
                    ContaCorrente = new ContaCorrenteModel()
                    {
                        NumeroContaCorrente = NumeroContaCorrente,
                        Saldo = new SaldoModel()
                        {
                            SaldoConta = SaldoContaCorrente
                        }
                    }
                }
            };
        }
    }
}
