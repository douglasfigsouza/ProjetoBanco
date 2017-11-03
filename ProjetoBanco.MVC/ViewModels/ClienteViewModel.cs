using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "Selecione uma cidade!")]
        public int cidadeId { get; set; }


        public int Id { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório,digite-O!")]
        [MinLength(5,ErrorMessage = "O nome deve conter no mínimo {0} caracteres")]
        [MaxLength(200, ErrorMessage = "O nome deve conter no máximo {0} caracteres")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório,digite-O!")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório,digite-O!")]
        public string rg { get; set; }

        [Required(ErrorMessage = "O campo rua é obrigatório,digite-O!")]
        [MinLength(5, ErrorMessage = "O rua deve conter no mínimo {0} caracteres")]
        [MaxLength(100, ErrorMessage = "O rua deve conter no máximo {0} caracteres")]
        public string rua { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório,digite-O!")]
        [MinLength(5, ErrorMessage = "O bairro deve conter no mínimo {0} caracteres")]
        [MaxLength(200, ErrorMessage = "O bairro deve conter no máximo {0} caracteres")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O campo N° é obrigatório,digite-O!")]
        public int num { get; set; }

        [Required(ErrorMessage = "O campo fone é obrigatório,digite-O!")]
        public string fone { get; set; }
        public DateTime dataCadastro { get; set; }

        [Required(ErrorMessage = "O campo nivel é obrigatório,digite-O!")]
        public char nivel { get; set; }
        public bool ativo { get; set; }
        public int estadoId { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
    }
}