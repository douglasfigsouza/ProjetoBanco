using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public string num { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}