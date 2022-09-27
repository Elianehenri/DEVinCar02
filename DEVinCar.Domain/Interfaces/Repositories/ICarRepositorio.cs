using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICarRepositorio 
    {

        IList<Car> ObterTodos();
        Car ObterPorId ( int id );
        void Inserir(Car car);
        void Excluir(Car car);
        void Atualizar(Car car);
       
        


    }
}
