using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IBancoAppService
    {
        string AddBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
        void Dispose();
    }
}
