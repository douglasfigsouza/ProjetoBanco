using ProjetoBanco.Domain.Clientes;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Contas
{
    public class ContaClienteAlteracao
    {
        public ContaClienteAlteracao()
        {
            Clientes = new List<ClienteDto>();
            contasClientes = new List<ContaClienteAlteracao>();
        }
        public int Id { get; set; }
        public int contaId { get; set; }
        public int clienteId { get; set; }
        public List<ClienteDto> Clientes { get; set; }
        public string conta { get; set; }
        public int agencia { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
        public int idCliContaCliente { get; set; }
        public List<ContaClienteAlteracao> contasClientes { get; set; }
    }
}
