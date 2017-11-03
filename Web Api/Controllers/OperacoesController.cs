using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacoesRepository _operacoesRepository;
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private readonly Notifications _notifications;

        public OperacoesController(IOperacoesRepository operacoesRepository, Notifications notifications, IOperacoesRealizadasRepository operacoesRealizadasRepository)
        {
            _operacoesRepository = operacoesRepository;
            _notifications = notifications;
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
        }

        public IHttpActionResult AddOperacao(Operacoes op)
        {
            _operacoesRepository.AddOperacao(op);
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
            _operacoesRealizadasRepository.Deposito(operacoesRealizadas);
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
            transact = _operacoesRepository.VerificaDadosTransferencia(transacao);
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
            _operacoesRealizadasRepository.Transferencia(operacoes);
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
            _operacoesRealizadasRepository.Saque(operacoesRealizadas);
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
            transact = _operacoesRepository.VerificaDadosTransacao(transacao);
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
            transact = _operacoesRepository.ConsultaSaldo(transacao);
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
            transacts = _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(dadosGetOpReal);
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
            estorno = _operacoesRealizadasRepository.GetOpRealizadaEstornoById(int.Parse(Id));
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
            _operacoesRealizadasRepository.ConfirmEstorno(estorno.Id);
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
            List<Estorno> opsEstornos = new List<Estorno>(_operacoesRealizadasRepository.GetAllOperacoesEstorno());
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
