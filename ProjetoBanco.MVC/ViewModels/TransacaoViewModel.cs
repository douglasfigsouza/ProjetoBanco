

using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.MVC.ViewModels
{
    public class TransacaoViewModel
    {
        public int op { get; set; }

        [Required]
        public string conta { get; set; }
        [Required]
        public string agencia { get; set; }
        public int clienteId { get; set; }
        [Required]
        public string valor { get; set; }
        public string nome { get; set; }
        public int bancoId { get; set; }
        public int contaId { get; set; }
        public string senhaCli { get; set;}
    }
}