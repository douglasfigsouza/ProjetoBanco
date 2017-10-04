using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Domain.Entities
{
    public class Agencia
    {
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public int CidadeId { get; set; }
    }
}
