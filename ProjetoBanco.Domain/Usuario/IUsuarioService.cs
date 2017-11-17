namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioService
    {
        UsuarioDto VerificaLogin(UsuarioDto usuario);
        UsuarioDto GetByUsuarioId(int id);
    }
}
