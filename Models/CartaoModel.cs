using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace SistemaBancarioWebAPI.Models
{
    public class CartaoModel
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; } = default!;
        public int Cvv { get; set; } = default!;
        public DateTime DataValidadeCartao { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public PessoaModel Pessoa { get; set; }
        public ContaCorrenteModel ContaCorrente { get; set; } = default!;
    }
}
