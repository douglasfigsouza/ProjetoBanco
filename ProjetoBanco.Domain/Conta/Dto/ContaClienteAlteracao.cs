using ProjetoBanco.Domain.Clientes.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public class ContaClienteAlteracao
    {
        public ContaClienteAlteracao()
        {
            Clientes= new List<Cliente>();
        }
        public int Id { get; set; }
        public List<Cliente> Clientes { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
    }
}
