using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICarService
    {
        IList<Car> ObterTodos();
        CarDTO ObterPorId(int id);
        void Inserir(CarDTO car);
        void Excluir(int id);
        void Atualizar(CarDTO car);
        
    }
}
