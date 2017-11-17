using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacaoService _operacaoService;
        private readonly IOperacaoRealizadaService _operacaoRealizadaService;
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private readonly IOperacoesRepository _operacoesRepository;
        private readonly Notifications _notifications;

        public OperacoesController(Notifications notifications, IOperacaoService operacaoService, IOperacaoRealizadaService operacaoRealizadaService, IOperacoesRepository operacoesRepository, IOperacoesRealizadasRepository operacoesRealizadasRepository)
        {
            _notifications = notifications;
            _operacaoService = operacaoService;
            _operacaoRealizadaService = operacaoRealizadaService;
            _operacoesRepository = operacoesRepository;
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
        }

        public IHttpActionResult PostOperacao(Operacoes op)
        {
            try
            {
                _operacoesRepository.PostOperacao(op);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult Deposito(OperacoesRealizadas operacoesRealizadas)
        {
            try
            {
                _operacoesRealizadasRepository.Deposito(operacoesRealizadas);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }

        }

        public IHttpActionResult VerificaDadosTransferencia(Transacao transacao)
        {
            try
            {
                var transact = new Transacao();
                transact = _operacaoService.VerificaDadosTransferencia(transacao);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(transact);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult Transferencia(List<OperacoesRealizadas> operacoes)
        {
            try
            {
                _operacaoRealizadaService.Transferencia(operacoes);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult Saque(OperacoesRealizadas operacoesRealizadas)
        {
            try
            {
                _operacaoRealizadaService.Saque(operacoesRealizadas);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult VerificaDadosTransacao(Transacao transacao)
        {
            try
            {
                var transact = new Transacao();
                transact = _operacaoService.VerificaDadosTransacao(transacao);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(transact);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult ConsultaSaldo(Transacao transacao)
        {
            try
            {
                var transact = new Transacao();
                transact = _operacaoService.ConsultaSaldo(transacao);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(transact);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult GetAllOperacoesPorContaParaEstorno(string conta, string senha, string agencia)
        {
            try
            {
                List<Estorno> transacts = new List<Estorno>();
                DadosGetOpReal dadosGetOpReal = new DadosGetOpReal
                {
                    agencia = int.Parse(agencia),
                    senha = senha,
                    conta = conta
                };
                transacts = _operacaoRealizadaService.GetAllOperacoesPorContaParaEstorno(dadosGetOpReal);
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(transacts);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

        public IHttpActionResult GetOpRealizadaEstornoById(string Id)
        {
            try
            {
                var estorno = new Estorno();
                estorno = _operacaoRealizadaService.GetOpRealizadaEstornoById(int.Parse(Id));
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(estorno);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult confirmEstorno(Estorno estorno)
        {
            try
            {
                _operacoesRealizadasRepository.ConfirmEstorno(estorno.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetAllOperacoesEstorno()
        {
            try
            {
                List<Estorno> opsEstornos = new List<Estorno>(_operacaoRealizadaService.GetAllOperacoesEstorno());
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(opsEstornos);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult ExtratoPorData(DadosGetOpReal dadosGetOp)
        {
            try
            {
                List<Estorno> opsEstornos = new List<Estorno>(_operacaoRealizadaService.GetExtratoPorData(dadosGetOp));
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(opsEstornos);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
    }
}
