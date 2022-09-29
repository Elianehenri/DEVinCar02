using DEVinCar.Domain.DTOs;
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
            _cityRepositorio.Inserir(new City(city));
        }

        public CityDTO ObterPorId(int id)
        {
           return new CityDTO(_cityRepositorio.ObterPorId(id));
        }

        public IList<City> ObterTodos()
        {
           return _cityRepositorio.ObterTodos();    
        }
    }
}
