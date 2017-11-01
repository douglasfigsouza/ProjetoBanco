using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface ICidadesAppService
    {
        HttpResponseMessage GetCidadesByEstadoId(int id);
    }
}
