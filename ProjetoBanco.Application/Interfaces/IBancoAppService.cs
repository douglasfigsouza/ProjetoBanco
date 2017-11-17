using ProjetoBanco.Domain.Bancos;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IBancoAppService
    {
        HttpResponseMessage PostBanco(Banco banco);
        HttpResponseMessage GetAllBancos();
    }
}
