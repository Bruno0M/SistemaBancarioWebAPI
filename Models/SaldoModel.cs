using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancarioWebAPI.Models
{
    public class SaldoModel
    {
        public int Id { get; set; }
        public decimal SaldoConta { get; set; }
        public int ContaCorrenteId { get; set; }
        [JsonIgnore]
        public ContaCorrenteModel ContaCorrente { get; set;}
    }
}
