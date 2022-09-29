using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ISaleCarRepositorio
    {
        IList<SaleCar> ObterTodos();
        SaleCar ObterPorId(int id);
        void Inserir(SaleCar saleCar);
        void Excluir(SaleCar saleCar);
        void Atualizar(SaleCar saleCar);
    }
}
