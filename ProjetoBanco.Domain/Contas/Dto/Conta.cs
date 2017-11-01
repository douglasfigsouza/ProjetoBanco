using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public class Conta
    {
        public Conta()
        {
            contaClientes = new List<ContaCliente>();
        }
        public int Id { get; set; }
        public string num { get; set; }
        public string senha { get; set; }
        public char tipo { get; set; }
        public bool ativo { get; set; }
        public List<ContaCliente> contaClientes { get; set; }
    }
}
