namespace ProjetoBanco.Domain.Agencias
{
    public class AgenciaDto
    {
        public int agencia { get; set; }
        public int bancoId { get; set; }
        public int CidadeId { get; set; }
        public bool ativo { get; set; }
        public string banco { get; set; }
    }
}
