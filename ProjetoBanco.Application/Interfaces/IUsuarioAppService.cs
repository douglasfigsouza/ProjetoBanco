using ProjetoBanco.Domain.Usuarios;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        HttpResponseMessage PostUsuario(UsuarioDto usuario);
        HttpResponseMessage VerificaLogin(UsuarioDto usuario);
        HttpResponseMessage GetByUsuarioId(int id);
        HttpResponseMessage GetAllUsuarios();
        HttpResponseMessage PutUsuario(UsuarioDto usuario);
    }
}
