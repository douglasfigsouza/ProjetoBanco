namespace ProjetoBanco.MVC.ViewModels
{
    public class TransacaoViewModel
    {
        public int op { get; set; }
        public char nivel { get; set;}
        public string conta { get; set; }
        public string agencia { get; set; }
        public int clienteId { get; set; }
        public string valor { get; set; }
        public string nome { get; set; }
        public int bancoId { get; set; }
        public int contaId { get; set; }
        public string senhaCli { get; set;}
        public string error { get; set; }
    }
}