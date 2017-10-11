using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoBanco.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        public int clienteId { get; set; }
        [Required(ErrorMessage = "Esse campo é requerido")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Esse campo é requerido")]
        public string senha { get; set; }
        public bool ativo { get; set; }
    }
}