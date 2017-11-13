using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;

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

        public void AddAgencia(Agencias.AgenciaDto agencia)
        {
            try
            {
                _agenciaRepository.AddAgencia(agencia);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar agência! Erro {e.Message}");
            }
        }

        public Agencias.AgenciaDto GetAgenciaByNum(int numAgencia)
        {
            var agencia = new Agencias.AgenciaDto();
            try
            {
                agencia = _agenciaRepository.GetAgenciaByNum(numAgencia);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar agência com o numero informado! Erro {e.Message}");
            }
            if (agencia.agencia == 0)
            {
                _notifications.Notificacoes.Add("Nenhuma agência encontrada!");
            }
            return agencia;
        }

        public IEnumerable<Agencias.AgenciaDto> GetAllAgencias()
        {
            IEnumerable<Agencias.AgenciaDto> agencias = new List<Agencias.AgenciaDto>();
            try
            {
                agencias = _agenciaRepository.GetAllAgencias();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar agências! Erro {e.Message}");
            }
            return agencias;
        }

        public void UpdateAgencia(Agencias.AgenciaDto agencia)
        {
            try
            {
                _agenciaRepository.UpdateAgencia(agencia);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar agência! Erro {e.Message}");
            }
        }
    }
}
