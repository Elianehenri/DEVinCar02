using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepositorio _cityRepositorio;
        private readonly IStateService _stateService;
        public CityService(ICityRepositorio cityRepositorio)
        {
            _cityRepositorio = cityRepositorio;
        }

        public void Atualizar(CityDTO city)
        {
            var cityDb = _cityRepositorio.ObterPorId(city.Id);
            cityDb.Update(city);
            _cityRepositorio.Atualizar(cityDb);
        }

        public void Excluir(int id)
        {
            var city = _cityRepositorio.ObterPorId(id);
             _cityRepositorio.Excluir(city);
        }

        public void Inserir(CityDTO city)
        {
            var state = _stateService.ObterPorId(city.Id);
            if (state == null)
            {
                throw new NaoExisteException("The states does not exist!");
            }
      

            _cityRepositorio.Inserir(new City(city));
        }

        public CityDTO ObterPorId(int id)
        {
           return new CityDTO(_cityRepositorio.ObterPorId(id));
        }

        public IList<City> ObterPorNomeCity(string? name)//, int stateId
        {
            var query = _cityRepositorio.Query();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }
            return query.ToList();
        }

        public IList<City> ObterTodos()
        {
           return _cityRepositorio.ObterTodos();    
        }
    }
}
