using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using System.Net.Http;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IOperacaoServiceDomain
    {
        HttpResponseMessage AddOperacao(Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao, int op);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        decimal ConsultaSaldo(Transacao transacao);
    }
}
