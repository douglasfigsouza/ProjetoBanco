using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        public int clienteId { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
    }
}