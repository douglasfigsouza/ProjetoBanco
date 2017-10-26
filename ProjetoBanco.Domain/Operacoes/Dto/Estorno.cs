using System;

namespace ProjetoBanco.Domain.Operacoes.Dto
{
    public class Estorno
    {
        public int Id { get; set; }
        public int opId { get; set; }
        public string descricao { get; set; }
        public DateTime dataOp { get; set; }
        public string dataFormatada { get; set; }
        public decimal valorOp { get; set; }
        public decimal saldoAnterior { get; set; }
        public int agencia { get; set; }
        public string conta { get; set; }
        public string cliente { get; set; }
    }
}
