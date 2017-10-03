using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace ProjetoBanco.MVC.ViewModels
{
    public class BancoViewModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
    }
}