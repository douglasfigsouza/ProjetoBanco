using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddAgencia(Agencias.Agencia agencia)
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

        public Agencias.Agencia GetAgenciaByNum(int numAgencia)
        {
            var agencia = new Agencias.Agencia();
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

        public IEnumerable<Agencias.Agencia> GetAllAgencias()
        {
            IEnumerable<Agencias.Agencia> agencias = new List<Agencias.Agencia>();
            try
            {
                agencias = _agenciaRepository.GetAllAgencias();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar agências! Erro {e.Message}");
            }
            if (agencias.Count() == 0)
            {
                _notifications.Notificacoes.Add("Agências não encontradas!");
            }
            return agencias;
        }

        public void UpdateAgencia(Agencias.Agencia agencia)
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
