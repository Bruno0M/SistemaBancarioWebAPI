using SistemaBancarioWebAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SistemaBancarioWebAPI.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public decimal ValorCompra {  get; set;}
        public DateTime DataCompra { get; set; }
        public FormaPagamento FormaPagamento { get; set;}
        public bool Situacao { get; set; } = false;

    }
}