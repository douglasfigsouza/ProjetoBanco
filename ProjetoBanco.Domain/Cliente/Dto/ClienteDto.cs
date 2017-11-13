using System;

namespace ProjetoBanco.Domain.Clientes
{
    public class ClienteDto
    {
        public int cidadeId { get; set; }
        public int estadoId { get; set; }
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int num { get; set; }
        public string fone { get; set; }
        public DateTime dataCadastro { get; set; }
        public char nivel { get; set; }
        public bool ativo { get; set; }

    }
}
