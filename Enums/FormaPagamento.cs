using System.Text.Json.Serialization;

namespace SistemaBancarioWebAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FormaPagamento
    {
        Debito,
        Credito
    }
}
