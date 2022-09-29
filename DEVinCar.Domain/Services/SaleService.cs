
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepositorio _saleRepositorio;

        public SaleService(ISaleRepositorio saleRepositorio)
        {
            _saleRepositorio = saleRepositorio;
        }

        public void Atualizar(SaleDTO sale)
        {
            var saleDb = _saleRepositorio.ObterPorId(sale.Id);
            saleDb.Update(sale);
            _saleRepositorio.Atualizar(saleDb);
        }

        public void Excluir(int id)
        {
            var sale = _saleRepositorio.ObterPorId(id);
            _saleRepositorio.Excluir(sale);
        }

        public void Inserir(SaleDTO sale)
        {
            _saleRepositorio.Inserir(new Sale(sale));
        }

        public SaleDTO ObterPorId(int id)
        {
            return new SaleDTO(_saleRepositorio.ObterPorId(id));
        }

        public IList<Sale> ObterTodos()
        {
           return _saleRepositorio.ObterTodos();
        }
    }
}
