using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Agencia
{
    public class AgenciaService : IAgenciaService
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly Notifications _notifications;

        public AgenciaService(IAgenciaRepository agenciaRepository, Notifications notifications)
        {
            _agenciaRepository = agenciaRepository;
            _notifications = notifications;
        }
        public Agencias.AgenciaDto GetAgenciaByNum(int numAgencia)
        {
            var agencia = new Agencias.AgenciaDto();
            agencia = _agenciaRepository.GetAgenciaByNum(numAgencia);
            if (agencia.agencia == 0)
            {
                _notifications.Notificacoes.Add("Nenhuma agência encontrada!");
            }
            return agencia;
        }

    }
}
