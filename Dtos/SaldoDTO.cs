using SistemaBancarioWebAPI.Models;
using SistemaBancarioWebAPI.Service;

namespace SistemaBancarioWebAPI.Dtos
{
    public class SaldoDTO
    {
        public int Id { get; set; }
        public string Pessoa { get; set; }
        public decimal SaldoContaCorrente { get; set; }

    }
}
