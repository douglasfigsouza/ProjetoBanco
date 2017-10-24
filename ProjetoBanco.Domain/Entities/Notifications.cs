using System.Collections.Generic;

namespace ProjetoBanco.Domain.Entities
{
    public class Notifications
    {
        public List<string> Notificacoes { get; set; }

        public Notifications()
        {
                Notificacoes = new List<string>();
        }
    }
}
