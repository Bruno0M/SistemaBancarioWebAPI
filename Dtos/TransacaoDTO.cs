using SistemaBancarioWebAPI.Enums;
using SistemaBancarioWebAPI.Models;
using System.Globalization;

namespace SistemaBancarioWebAPI.Dtos
{
    public class TransacaoDTO
    {
        public int Id { get; set; }
        public string NumeroContaCorrente { get; set; }
        public string NumeroCartao { get; set; }
        public int Cvv { get; set; }
        public DateTime DataValidadeCartao { get; set; }
        public decimal ValorCompra { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public DateTime DataCompra { get; set; }
        public bool Situacao { get; set; } = false;


    }
}
