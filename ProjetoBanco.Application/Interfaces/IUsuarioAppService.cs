using ProjetoBanco.Domain.Usuarios;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        HttpResponseMessage AddUsuario(Usuario usuario);
        HttpResponseMessage VerificaLogin(Usuario usuario);
        HttpResponseMessage GetByUsuarioId(int id);
        HttpResponseMessage GetAllUsuarios();
        HttpResponseMessage UpdateUsuario(Usuario usuario);
    }
}
