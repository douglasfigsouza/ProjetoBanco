using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            usuarios = new List<UsuarioViewModel>();
        }
        public int clienteId { get; set; }
        [Required(ErrorMessage = "Esse campo é requerido")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Esse campo é requerido")]
        public string senha { get; set; }
        public bool ativo { get; set; }
        public string nomeCli { get; set;}
        public IEnumerable<UsuarioViewModel> usuarios;
    }
}