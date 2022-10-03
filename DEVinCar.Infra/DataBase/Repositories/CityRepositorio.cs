using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class CityRepositorio : BaseRepositorio<City, int>, ICityRepositorio
    {
        public CityRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
           
        }

        public IList<City> ObterPorNomeCity(int stateId, string? name)
        {
            return _contexto.Cities.Where(u => u.Name == name).ToList();
        }
    }
}
