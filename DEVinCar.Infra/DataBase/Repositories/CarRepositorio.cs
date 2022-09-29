
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class CarRepositorio : BaseRepositorio<Car, int>, ICarRepositorio
    {
        public CarRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
        }

        public List<Car> ObterPorNome(string nome)
        {
            return _contexto.Cars.Where(x => x.Name == nome).ToList();
        }
    }
}
