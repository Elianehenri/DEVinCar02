using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepositorio _carRepositorio;

        public CarService(ICarRepositorio carRepositorio)
        {
            _carRepositorio = carRepositorio;
        }

        public void Atualizar(CarDTO car)
        {
            var carDb = _carRepositorio.ObterPorId(car.Id);
            carDb.Update(car);
            _carRepositorio.Atualizar(carDb);
        }

        public void Excluir(int id)
        {
            var car = _carRepositorio.ObterPorId(id);
            _carRepositorio.Excluir(car);
        }

        public void Inserir(CarDTO car)
        {
            _carRepositorio.Inserir(new Car(car));
        }

        public CarDTO ObterPorId(int id)
        {
            return new CarDTO(_carRepositorio.ObterPorId(id));
        }

        public IList<Car> ObterTodos()
        {
            throw new NotImplementedException();
        }

      

        
    }
}

