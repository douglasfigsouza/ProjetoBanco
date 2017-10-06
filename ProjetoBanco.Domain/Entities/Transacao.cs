using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Domain.Entities
{
    public class Transacao
    {
        public string conta { get; set; }
        public int agencia  { get; set; }
        public int clienteId { get; set; }
        public decimal valor { get; set;}
        public string nome { get; set; }
        public int bancoId { get; set; }
        public int contaId { get; set; }
        public DateTime dataOp { get; set; }
    }
}
