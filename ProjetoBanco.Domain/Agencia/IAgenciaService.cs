namespace ProjetoBanco.Domain.Agencia
{
    public interface IAgenciaService
    {
        Agencias.AgenciaDto GetAgenciaByNum(int agencia);
    }
}
