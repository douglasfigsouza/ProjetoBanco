using ProjetoBanco.Domain.Bancos;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IBancoAppService
    {
        HttpResponseMessage AddBanco(Banco banco);
        HttpResponseMessage GetAllBancos();
    }
}
