using System.Collections.Generic;

namespace ProjetoBanco.MVC.ViewModels
{
    public class AgenciaViewModel
    {
        public AgenciaViewModel()
        {
            agencias = new List<AgenciaViewModel>();
        }
        public string agencia { get; set; }
        public int bancoId { get; set; }
        public int CidadeId { get; set; }
        public bool ativo { get; set; }
        public string banco { get; set; }
        public List<AgenciaViewModel> agencias { get; set; }
    }
}