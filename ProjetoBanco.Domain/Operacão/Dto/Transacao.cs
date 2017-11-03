using System;

namespace ProjetoBanco.Domain.Operacoes.Dto
{
    public class Transacao
    {
        public int op { get; set; }
        public string conta { get; set; }
        public int agencia  { get; set; }
        public int clienteId { get; set; }
        public decimal valor { get; set;}
        public string nome { get; set; }
        public int bancoId { get; set; }
        public int contaId { get; set; }
        public DateTime dataOp { get; set; }
        public char nivel { get; set;}
        public string senhaCli { get; set; }
    }
}
