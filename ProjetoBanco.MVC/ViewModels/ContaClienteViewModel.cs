using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaClienteViewModel
    {
        public int contaId { get; set; }
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public int clienteId { get; set; }
    }
}