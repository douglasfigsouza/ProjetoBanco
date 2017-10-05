using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBanco.Domain.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public string  num { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}
