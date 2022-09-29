
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


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
