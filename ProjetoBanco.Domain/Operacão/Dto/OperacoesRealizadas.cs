using System;

namespace ProjetoBanco.Domain.Operacoes.Dto
{
    public class OperacoesRealizadas
    {
        public int operacaoId { get; set; }
        public int clienteId { get; set; }
        public int contaId { get; set; }
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public DateTime dataOp { get; set; }
        public decimal valorOp { get; set; }
        public decimal saldoAnterior { get; set; }
    }
}
