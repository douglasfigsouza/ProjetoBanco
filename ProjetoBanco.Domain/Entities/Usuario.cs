using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Domain.Entities
{
    public class Usuario
    {
        public int clienteId  { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public char nivel { get; set; }
    }
}
