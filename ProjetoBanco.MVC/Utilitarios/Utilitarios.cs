using System.Text.RegularExpressions;

namespace ProjetoBanco.MVC.Utilitarios
{
    public class Utilitarios
    {
        public static string retiraMask(string campo)
        {
            return campo.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ","");
        }
        public static string retiraMaskMoney(string campo)
        {
            return Regex.Replace(campo, "[^0-9,]", "");
        }

    }
}