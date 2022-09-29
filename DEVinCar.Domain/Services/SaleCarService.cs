using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Services
{
    public class SaleCarService : ISaleCarService
    {
        private readonly ISaleCarRepositorio _saleCarRepositorio;

        public SaleCarService(ISaleCarRepositorio saleCarRepositorio)
        {
            _saleCarRepositorio = saleCarRepositorio;
        }

        public void Atualizar(SaleCarDTO sale)
        {
            var saleCarDb = _saleCarRepositorio.ObterPorId(sale.CarId);
            saleCarDb.Update(sale);
            _saleCarRepositorio.Atualizar(saleCarDb);
        }

        public void Excluir(int id)
        {
            var saleCar = _saleCarRepositorio.ObterPorId(id);
            _saleCarRepositorio.Excluir(saleCar);
        }

        public void Inserir(SaleCarDTO saleCar)
        {
            _saleCarRepositorio.Inserir(new SaleCar(saleCar));
        }

        public SaleCarDTO ObterPorId(int id)
        {
            return new SaleCarDTO(_saleCarRepositorio.ObterPorId(id));
        }

        public IList<SaleCar> ObterTodos()
        {
            return _saleCarRepositorio.ObterTodos();
        }
    }
}
