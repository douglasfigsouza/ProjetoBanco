
using System.Collections.Generic;
namespace ProjetoBanco.MVC.ViewModels
{
    public class CombosContaViewModel
    {
        public string banco { get; set; }
        public List<AgenciaViewModel> Agencias { get; set; }
        public List<ClienteViewModel> Clientes { get; set; }
    }
}