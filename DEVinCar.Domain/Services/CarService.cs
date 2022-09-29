 
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
            var carExiste = _carRepositorio.ObterPorNome(car.Name);

            if (carExiste.Count > 0)
                throw new DuplicadoException("Carro já existe");
            //throw new Exception("Ja tem caro");


            _carRepositorio.Inserir(new Car(car));
                            
           
        }

        public CarDTO ObterPorId(int id)
        {
            return new CarDTO(_carRepositorio.ObterPorId(id));
        }

        public List<CarDTO> ObterPorNome(string nome)
        {
            var jaExiste = _carRepositorio.ObterPorNome(nome);

            if (jaExiste.Count > 0)
               
               throw new DuplicadoException("Carro já existe");
            return _carRepositorio.ObterPorNome(nome)
                .Select(c => new CarDTO(c))
                .ToList();
        }

        public IList<Car> ObterTodos()
        {
            return _carRepositorio.ObterTodos();
        }
        
    }
}

