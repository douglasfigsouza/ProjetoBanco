using System.Collections.Generic;

namespace ProjetoBanco.Domain.Entities
{
    public class ContaClienteAlteracao
    {
        public List<string> Clientes  { get; set; }
        public string  conta { get; set; }
        public string senha { get; set; }
    }
}
