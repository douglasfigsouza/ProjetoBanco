using ProjetoBanco.Domain.Clientes;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public class ContaCliente
    {
        public ContaCliente()
        {
            clientes = new List<ClienteDto>();
        }
        public int contaId { get; set; }
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public int clienteId { get; set; }
        public string nome{ get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public List<ClienteDto> clientes{ get; set; }
    }
}
