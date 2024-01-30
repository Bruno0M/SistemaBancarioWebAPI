using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBancarioWebAPI.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public CartaoModel Cartao { get; set; }


    }

}
