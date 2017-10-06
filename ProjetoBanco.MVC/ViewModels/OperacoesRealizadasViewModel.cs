using System;

namespace ProjetoBanco.MVC.ViewModels
{
    public class OperacoesRealizadasViewModel
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