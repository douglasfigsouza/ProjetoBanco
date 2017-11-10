using System;

namespace ProjetoBanco.Domain.Operacoes.Dto
{
    public class DadosGetOpReal
    {
        public int agencia { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime dataFinal { get; set; }
    }
}
