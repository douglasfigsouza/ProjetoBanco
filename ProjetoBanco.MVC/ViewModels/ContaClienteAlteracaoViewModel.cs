using System.Collections.Generic;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaClienteAlteracaoViewModel
    {
        public ContaClienteAlteracaoViewModel()
        {
            Clientes = new List<ClienteViewModel>();
        }
        public int Id { get; set; }
        public int contaId { get; set; }
        public int clienteId { get; set; }
        public List<ClienteViewModel> Clientes { get; set; }
        public string conta { get; set; }
        public int agencia { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
        public int idCliContaCliente { get; set; }
    }
}