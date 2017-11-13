namespace ProjetoBanco.MVC.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public string num { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
        public int dllAgencias { get; set; }
        public bool ativo { get; set; }
        public string conta { get; set;}
    }
}