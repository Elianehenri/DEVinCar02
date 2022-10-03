
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepositorio _saleRepositorio;
        private readonly IUserService _userService;
        private readonly IDeliveryService _deliveryService;

        public SaleService(ISaleRepositorio saleRepositorio, IUserService userService, IDeliveryService deliveryService)
        {
            _saleRepositorio = saleRepositorio;
            _userService = userService;
            _deliveryService = deliveryService;
        }

        public void Atualizar(SaleDTO sale)//putt
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

        public void Inserir(SaleDTO sale)//post certo
        {

            var user = _userService.ObterPorId(sale.Id  );
            if (user == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

            var buyer = _userService.ObterPorId(sale.BuyerId);
            if (buyer == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

            if (sale.SaleDate == null)
            {
                sale.SaleDate = DateTime.Now;
            }

           
            _saleRepositorio.Inserir(new Sale(sale));
        }

        public void Inserir(BuyDTO sale)//certo
        {
            var user = _userService.ObterPorId(sale.Id);
            if (user == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

            var buyer = _userService.ObterPorId(sale.SellerId);
            if (buyer == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

            if (sale.SaleDate == null)
            {
                sale.SaleDate = DateTime.Now;
            }


            _saleRepositorio.Inserir(new Sale(sale));
        }

       
        public SaleDTO ObterPorId(int id)
        {


            return new SaleDTO(_saleRepositorio.ObterPorId(id));

        }

       

        public void InserirDelivery(int saleId, DeliveryDTO deliveryDTO)
        {//var delivery = _saleRepositorio.InserirDelivery(saleId.Id,deliveryDTO.Id,);
           // var delivey = _saleRepositorio.ObterPorId(saleId);

         

            if (_saleRepositorio.ObterPorId (saleId) == null)
            {
                throw new NaoExisteException("the sale does not exist.");
            }

            
            _saleRepositorio.Inserir(new Sale());
            //return Inserir("{saleId}/deliver", query.Id);
        }

        public IList<Sale> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Inserir(SaleCarDTO saleCarDTO)
        {
            _saleRepositorio.Inserir(new Sale(saleCarDTO.SaleId,
                                               saleCarDTO.CarId,
                                               saleCarDTO.Amount,
                                              saleCarDTO.UnitPrice));
        }
    }
      
    
}
