﻿using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesRealizadasAppService : IOperacaoesRealizadasAppService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private readonly IOperacoeRealizadaService _operacoesRealizadaService;
        private readonly Notifications _notifications;

        public OperacoesRealizadasAppService(IOperacoeRealizadaService operacoesRealizadaService, IOperacoesRealizadasRepository operacoesRealizadasRepository, Notifications notifications)
        {
            _operacoesRealizadaService = operacoesRealizadaService;
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
            _notifications = notifications;
        }
        public HttpResponseMessage Deposito(OperacoesRealizadas operacaoRealizada)
        {
            HttpResponseMessage response;

            response = HttpClientConf.HttpClientConfig("Operacoes")
                    .PostAsJsonAsync("Deposito", operacaoRealizada).Result;
            return response;
        }

        public HttpResponseMessage Transferencia(List<OperacoesRealizadas> operacoes)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("Transferencia", operacoes).Result;
            return response;

        }

        public HttpResponseMessage GetOpRealizadaEstornoById(int Id)
        {

            HttpResponseMessage response;
            //Create a query
            HttpClient client = new HttpClient();
            response = client.GetAsync(HttpClientConf.HttpClientConfigGet("Operacoes/GetOpRealizadaEstornoById", new
            {
                Id
            })).Result;
            return response;
        }

        public HttpResponseMessage ConfirmEstorno(Estorno estorno)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("ConfirmEstorno",estorno).Result;
            return response;
        }

        public HttpResponseMessage GetAllOperacoesEstorno()
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .GetAsync("GetAllOperacoesEstorno").Result;
            return response;
        }

        public HttpResponseMessage Saque(OperacoesRealizadas operacaoRealizada)
        {
            HttpResponseMessage response;
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("Saque", operacaoRealizada).Result;
            return response;
        }
        [Route("api/Operacoes/GetAllOperacoesPorContaParaEstorno{dadosGetOpReal}")]

        public HttpResponseMessage GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOpReal)
        {
            HttpResponseMessage response;
            //string parametros = "conta=" + dadosGetOpReal.conta + "&senha=" + dadosGetOpReal.senha + "&agencia=" +
            //                    dadosGetOpReal.agencia;
            ////Create a query
            HttpClient client = new HttpClient();
            response = client
                .GetAsync(HttpClientConf.HttpClientConfigGet("Operacoes/GetAllOperacoesPorContaParaEstorno",dadosGetOpReal)).Result;

            return response;
        }

    }
}