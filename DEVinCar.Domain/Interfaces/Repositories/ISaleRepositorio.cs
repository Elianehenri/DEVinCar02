using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ISaleRepositorio
    {
        IList<Sale> ObterTodos();
        Sale ObterPorId(int id);
        void Inserir(Sale sale);
        void Excluir(Sale sale);
        void Atualizar(Sale sale);
    }
}
