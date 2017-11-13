
namespace ProjetoBanco.Domain.Usuarios
{
    public class UsuarioDto
    {
        public int clienteId  { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public char nivel { get; set; }
        public string nomeCli { get; set; }
        public bool ativo { get; set; }
    }
}
