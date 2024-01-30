namespace SistemaBancarioWebAPI.Dtos
{
    public class CartaoDTO
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; } = default!;
        public int Cvv { get; set; } = default!;
        public DateTime DataValidadeCartao { get; set; }
    }
}
