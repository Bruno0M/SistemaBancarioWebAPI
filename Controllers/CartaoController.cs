using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBancarioWebAPI.Dtos;
using SistemaBancarioWebAPI.Enums;
using SistemaBancarioWebAPI.Models;
using SistemaBancarioWebAPI.Service;

namespace SistemaBancarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ICartao _cartaoInterface;
        public CartaoController(ICartao cartaoInterface)
        {
            _cartaoInterface = cartaoInterface;
        }

        [HttpPost("CriarPessoa")]
        public async Task<ActionResult<CriarPessoaDTO>> CreateCartao([FromBody] CriarPessoaDTO novaPessoa)
        {
            return Ok(await _cartaoInterface.CreatePessoa(novaPessoa));
        }

        [HttpPost("TransacaoPagamento")]
        public async Task<ServiceResponse<TransacaoDTO>> TransacaoPagamento([FromBody] TransacaoDTO transacao)
        {
            var transacaoDTO = await _cartaoInterface.TransacaoPagamento(transacao);
            return transacaoDTO;
        }

        [HttpGet("ListarSaldos")]
        public async Task<ActionResult<List<SaldoDTO>>> GetSaldos()
        {
            return Ok(await _cartaoInterface.GetSaldos());
        }

        [HttpDelete]
        public async Task<ServiceResponse<PessoaModel>> DeletePessoa(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = await _cartaoInterface.DeletePessoa(id);
            return serviceResponse;
        }

        [HttpPut("EditarCartao/{id}")]
        public async Task<ServiceResponse<CartaoDTO>> AtualizarCartao(int id, CartaoDTO editarCartao)
        {
            var cartoes = await _cartaoInterface.AtualizarCartao(id, editarCartao);
            return cartoes;
        }

    }
}
