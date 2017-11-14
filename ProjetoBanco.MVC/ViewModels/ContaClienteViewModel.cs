using System.Collections.Generic;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaClienteViewModel
    {
        public ContaClienteViewModel()
        {
            clientes = new List<ClienteViewModel>();
        }
        public int contaId { get; set; }
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public int clienteId { get; set; }
        public string nome { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public List<ClienteViewModel> clientes { get; set; }
    }
}