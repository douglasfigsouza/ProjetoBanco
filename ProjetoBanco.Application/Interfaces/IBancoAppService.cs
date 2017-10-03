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
        void AddBanco(Banco banco);
        Banco GetByBancoId(int id);
        IEnumerable<Banco> GetAllBancos();
        void UpdateBanco(Banco banco);
        void RemoveBanco(Banco banco);
        void Dispose();
    }
}
