using ProjetoBanco.Domain.Usuarios;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        HttpResponseMessage AddUsuario(UsuarioDto usuario);
        HttpResponseMessage VerificaLogin(UsuarioDto usuario);
        HttpResponseMessage GetByUsuarioId(int id);
        HttpResponseMessage GetAllUsuarios();
        HttpResponseMessage UpdateUsuario(UsuarioDto usuario);
    }
}
