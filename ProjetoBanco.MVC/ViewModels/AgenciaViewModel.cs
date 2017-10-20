using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.MVC.ViewModels
{
    public class AgenciaViewModel
    {
        public string agencia { get; set; }
        public int bancoId { get; set; }
        public int CidadeId { get; set; }
        public bool ativo { get; set; }
        public string banco { get; set; }
    }
}