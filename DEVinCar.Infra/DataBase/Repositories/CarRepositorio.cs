using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using DEVinCar.Domain.Interfaces.Repositories;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class CarRepositorio : BaseRepositorio<Car, Guid>, ICarRepositorio
    {
        public CarRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
        }

        public Car ObterPorId(int id)
        {
            return _contexto.Set<Car>().Where(c => c.Id == id).First();
        }

        //public IList<Car> ObterTodos(int id)
        //{
        //    return _contexto.Cars.Where(c => c.Id == id).ToList();
        //}
    }
}
