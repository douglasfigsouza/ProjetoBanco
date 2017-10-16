using System.Collections.Generic;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaClienteAlteracaoViewModel
    {
        public List<string> Clientes { get; set; }
        public string conta { get; set; }
        public string senha { get; set; }
    }
}