using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacaoService _operacaoService;
        private readonly IOperacaoRealizadaService _operacaoRealizadaService;
        private readonly Notifications _notifications;

        public OperacoesController(Notifications notifications, IOperacaoService operacaoService, IOperacaoRealizadaService operacaoRealizadaService)
        {
            _notifications = notifications;
            _operacaoService = operacaoService;
            _operacaoRealizadaService = operacaoRealizadaService;
        }

        public IHttpActionResult AddOperacao(Operacoes op)
        {
            _operacaoService.AddOperacao(op);
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

        public IHttpActionResult Deposito(OperacoesRealizadas operacoesRealizadas)
        {
            _operacaoRealizadaService.Deposito(operacoesRealizadas);
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

        public IHttpActionResult VerificaDadosTransferencia(Transacao transacao)
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

        public IHttpActionResult Transferencia(List<OperacoesRealizadas> operacoes)
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

        public IHttpActionResult Saque(OperacoesRealizadas operacoesRealizadas)
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

        public IHttpActionResult VerificaDadosTransacao(Transacao transacao)
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

        public IHttpActionResult ConsultaSaldo(Transacao transacao)
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

        public IHttpActionResult GetAllOperacoesPorContaParaEstorno(string conta, string senha, string agencia)
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

        public IHttpActionResult GetOpRealizadaEstornoById(string Id)
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
        public IHttpActionResult confirmEstorno(Estorno estorno)
        {
            _operacaoRealizadaService.ConfirmEstorno(estorno.Id);
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
        public IHttpActionResult GetAllOperacoesEstorno()
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
        public IHttpActionResult ExtratoPorData(DadosGetOpReal dadosGetOp)
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
    }
}
