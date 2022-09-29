using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ISaleCarService
    {
        IList<SaleCar> ObterTodos();
        SaleCarDTO ObterPorId(int id);
        void Inserir(SaleCarDTO saleCar);
        void Excluir(int id);
        void Atualizar(SaleCarDTO saleCar);
    }
}
