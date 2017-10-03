namespace ProjetoBanco.MVC.Utilitarios
{
    public class Utilitarios
    {
        public static string retiraMask(string campo)
        {
            return campo.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ","");
        }
    }
}