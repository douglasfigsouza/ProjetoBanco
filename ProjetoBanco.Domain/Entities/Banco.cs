using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Domain.Entities
{
    public class Banco
    {
        public int  Id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
    }
}
