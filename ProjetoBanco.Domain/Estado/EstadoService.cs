using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBanco.Domain.Estados
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private Notifications _notifications;

        public EstadoService(IEstadoRepository estadoRepository, Notifications notifications)
        {
            _estadoRepository = estadoRepository;
            _notifications = notifications;
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            IEnumerable<Estado> estados = new List<Estado>();
            estados = _estadoRepository.GetAllEstados();
            if (estados.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem estados cadastrados!");
            }
            return estados;
        }
    }
}
