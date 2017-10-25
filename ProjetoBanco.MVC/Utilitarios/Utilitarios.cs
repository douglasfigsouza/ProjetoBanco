using System;
using System.Text.RegularExpressions;

namespace ProjetoBanco.MVC.Utilitarios
{
    public class Utilitarios
    {
        public static string retiraMask(string campo)
        {
            if (campo == null) return null;
            else
            {
                return campo.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            }
        }
        public static string retiraMaskMoney(string campo)
        {
            return Regex.Replace(campo, "[^0-9,]", "");
        }

        public static string limpaMenssagemErro(string msgm)
        {
            return msgm.Replace("{", "").Replace("}", "").Replace("Message", "")
                .Replace(":", "").Replace("\"", "");
        }
    }
}