using System.Collections.Generic;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaClienteAlteracaoViewModel
    {
        public List<ClienteViewModel> Clientes { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
        public int Id { get; set; }
    }
}