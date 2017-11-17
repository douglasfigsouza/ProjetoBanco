using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private Notifications _notifications;

        public UsuarioService(IUsuarioRepository usuarioRepository, Notifications notifications)
        {
            _usuarioRepository = usuarioRepository;
            _notifications = notifications;
        }

        public UsuarioDto VerificaLogin(UsuarioDto usuario)
        {
            var user = new UsuarioDto();
            user = _usuarioRepository.VerificaLogin(usuario);
            if (usuario.nome == "")
            {
                _notifications.Notificacoes.Add("Usuário/Senha não conferem!");
            }
            return user;
        }

        public UsuarioDto GetByUsuarioId(int id)
        {
            var usuario = new UsuarioDto();
            usuario = _usuarioRepository.GetByUsuarioId(id);
            if (usuario.nome == "")
            {
                _notifications.Notificacoes.Add("Usuário não encontrado!");
            }
            return usuario;
        }
    }
}
