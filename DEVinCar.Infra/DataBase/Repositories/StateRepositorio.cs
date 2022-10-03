using DEVinCar.Domain.DTOs;
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
    public class StateRepositorio : BaseRepositorio<State, int>, IStateRepositorio
    {
        public StateRepositorio(DevInCarDbContext contexto) : base(contexto)
        {

        }

        //public void Inserir(CityDTO cityDTO)
        //{
        //    throw new NotImplementedException();
        //}

        public City ObterCityPorId(int stateId, int cityId)
        {
            return _contexto.Cities.FirstOrDefault(s => s.Id == stateId && s.Id== cityId);
        }

        public IList<State> ObterPorNome(string name)
        {
            return _contexto.States.Where(u => u.Name == name).ToList();
        }

        public IList<City> ObterPorNomeCity(int stateId, string? name)
        {
            return (IList<City>)_contexto.Cities.Where(s => s.Id == stateId && s.Name == name);
        }
    }
}
