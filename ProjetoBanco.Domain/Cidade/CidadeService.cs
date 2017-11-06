﻿using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBanco.Domain.Cidade
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly Notifications _notifications;

        public CidadeService(ICidadeRepository cidadeRepository, Notifications notifications)
        {
            _cidadeRepository = cidadeRepository;
            _notifications = notifications;
        }

        public IEnumerable<Cidades.Cidade> GetCidadesByEstadoId(int id)
        {
            IEnumerable<Cidades.Cidade> cidades = new List<Cidades.Cidade>();
            try
            {
                cidades = _cidadeRepository.GetCidadesByEstadoId(id);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar cidades! Erro {e.Message}");
            }
            if (cidades.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem cidades cadastradas!");
            }
            return cidades;
        }
    }
}
