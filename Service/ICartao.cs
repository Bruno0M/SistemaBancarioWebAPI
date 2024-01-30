using Microsoft.AspNetCore.Mvc;
using SistemaBancarioWebAPI.Dtos;
using SistemaBancarioWebAPI.Enums;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Service
{
    public interface ICartao
    {
        Task<ServiceResponse<CriarPessoaDTO>> CreatePessoa(CriarPessoaDTO novaPessoa);
        Task<ServiceResponse<TransacaoDTO>> TransacaoPagamento(TransacaoDTO transacoesDTO);

        Task<ServiceResponse<CartaoDTO>> AtualizarCartao(int id, CartaoDTO editarCartao);
        Task<ServiceResponse<List<SaldoDTO>>> GetSaldos();
        Task<ServiceResponse<PessoaModel>> DeletePessoa(int id);
    }
}
