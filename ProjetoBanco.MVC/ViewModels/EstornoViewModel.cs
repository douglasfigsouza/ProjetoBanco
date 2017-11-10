using System;

namespace ProjetoBanco.MVC.ViewModels
{
    public class EstornoViewModel
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
        public decimal saldo { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime dataFinal { get; set; }
        public string dataFormatadaInicial { get; set; }
        public string dataFormatadaFinal { get; set; }
    }
}