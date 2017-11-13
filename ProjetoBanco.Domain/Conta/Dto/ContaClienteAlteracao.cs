using ProjetoBanco.Domain.Clientes;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public class ContaClienteAlteracao
    {
        public ContaClienteAlteracao()
        {
            Clientes= new List<ClienteDto>();
        }
        public int Id { get; set; }
        public List<ClienteDto> Clientes { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
    }
}
