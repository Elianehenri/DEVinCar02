using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;


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
                throw new JaexisteException("Carro já existe");
            

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
               
               throw new JaexisteException("Carro já existe");
            return _carRepositorio.ObterPorNome(nome)
                .Select(c => new CarDTO(c))
                .ToList();
        }

        public IList<Car> ObterTodos(           
            string name,
            decimal? priceMin,
            decimal? priceMax)
        {
            var query = _carRepositorio.Query();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }
            //if (priceMin > priceMax)
            //{
            //    return BadRequest();
            //}
            if (priceMin.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice >= priceMin);
            }
            if (priceMax.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice <= priceMax);
            }
            return query.ToList();
        }

       
    }
}

