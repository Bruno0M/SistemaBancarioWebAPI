using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancarioWebAPI.Models
{
    public class ContaCorrenteModel
    {
        public int Id { get; set; }
        public string NumeroContaCorrente {  get; set; }
        public int CartaoId { get; set; }
        [JsonIgnore]
        public CartaoModel Cartao { get; set; }
        public SaldoModel Saldo { get; set; }
    }
}

    