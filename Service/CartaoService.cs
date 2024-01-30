using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBancarioWebAPI.DataContext;
using SistemaBancarioWebAPI.Dtos;
using SistemaBancarioWebAPI.Enums;
using SistemaBancarioWebAPI.Models;

namespace SistemaBancarioWebAPI.Service
{
    public class CartaoService : ICartao
    {

        private readonly ApplicationDbContext _context;

        public CartaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<CartaoDTO>> AtualizarCartao(int id, CartaoDTO editarCartao)
        {
            ServiceResponse<CartaoDTO> serviceResponse = new ServiceResponse<CartaoDTO>();

            try
            {
                CartaoModel cartao = _context.Cartoes.AsNoTracking().FirstOrDefault(x => x.Id == editarCartao.Id);

                if (cartao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado!";
                }

                cartao.NumeroCartao = editarCartao.NumeroCartao;
                cartao.Cvv = editarCartao.Cvv;
                cartao.DataValidadeCartao = editarCartao.DataValidadeCartao;

                _context.Cartoes.Update(cartao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = editarCartao;
                serviceResponse.Mensagem = "Pessoa Atualizada!";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CriarPessoaDTO>> CreatePessoa(CriarPessoaDTO pessoa)
        {
            ServiceResponse<CriarPessoaDTO> serviceResponse = new ServiceResponse<CriarPessoaDTO>();

            try
            {
                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os Dados!";
                }

                var novaPessoa = pessoa.ToEntity();

                var pessoaExiste = await _context.Pessoas.Where(p => p.Cpf == pessoa.Cpf 
                                                                && p.Cartao.NumeroCartao == pessoa.NumeroCartao
                                                                && p.Cartao.ContaCorrente.NumeroContaCorrente == pessoa.NumeroContaCorrente
                                                                && p.Cartao.Cvv == pessoa.Cvv)
                                                                .FirstOrDefaultAsync();

                if (novaPessoa != pessoaExiste)
                {
                    _context.Add(novaPessoa);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Essa pessoa já está cadastrada!";
                }
                    serviceResponse.Dados = pessoa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> DeletePessoa(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try
            {

                PessoaModel pessoa = _context.Pessoas.FirstOrDefault(x => x.Id == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada!";
                }

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
                serviceResponse.Mensagem = "Pessoa deletada!";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SaldoDTO>>> GetSaldos()
        {
            ServiceResponse<List<SaldoDTO>> serviceResponse = new ServiceResponse<List<SaldoDTO>>();

            try
            {
                var cartoes = await _context.Cartoes
                                    .Select(cartao => new SaldoDTO
                                    {
                                        Id = cartao.Id,
                                        Pessoa = cartao.Pessoa.Nome,
                                        SaldoContaCorrente = cartao.ContaCorrente.Saldo.SaldoConta
                                    })
                                    .ToListAsync();

                serviceResponse.Dados = cartoes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<TransacaoDTO>> TransacaoPagamento(TransacaoDTO transacoesDTO)
        {
            ServiceResponse<TransacaoDTO> serviceResponse = new ServiceResponse<TransacaoDTO>();

            try
            {
                var conta = await _context.Cartoes.Where(c => c.Id == transacoesDTO.Id
                                                        && c.NumeroCartao == transacoesDTO.NumeroCartao
                                                        && c.ContaCorrente.NumeroContaCorrente == transacoesDTO.NumeroContaCorrente
                                                        && c.Cvv == transacoesDTO.Cvv)
                                                        .FirstOrDefaultAsync();


                var transacoes = new TransacaoModel
                {
                    ValorCompra = transacoesDTO.ValorCompra,
                    DataCompra = transacoesDTO.DataCompra,
                    FormaPagamento = transacoesDTO.FormaPagamento,
                    Situacao = transacoesDTO.Situacao
                };

                var saldo = _context.Saldos.FirstOrDefault(x => x.Id == transacoesDTO.Id);

                if (conta != null)
                {
                    if (saldo.SaldoConta >= transacoesDTO.ValorCompra)
                    {
                        saldo.SaldoConta -= transacoesDTO.ValorCompra;
                        await _context.SaveChangesAsync();

                        transacoes.Situacao = true;
                    }
                    else
                    {
                        transacoes.Situacao = false;
                        serviceResponse.Mensagem = "Saldo insuficiente";
                    }

                        _context.Add(transacoes);
                        await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Insira os dados corretamente!";
                }
            
                serviceResponse.Dados = transacoesDTO;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

    }
}
