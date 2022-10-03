using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class SaleRepositorio : BaseRepositorio<Sale, int>, ISaleRepositorio
    {
        public SaleRepositorio(DevInCarDbContext contexto) : base(contexto)
        {

        }

        public Sale SellerPorId(int buyerId)
        {
            var seller = _contexto.Sales.Where(x => x.BuyerId == buyerId);
                return seller.FirstOrDefault(); 
        }
        
        public IList<Sale>   GetByIdBuy(int userId)
        {
            var sales = _contexto.Sales.Where(s => s.BuyerId == userId);
            return (sales.ToList());
        }
        public  IList<Sale> GetSalesBySellerId(int userId)
            {
            var sales = _contexto.Sales.Where(s => s.SellerId == userId);
            return (sales.ToList());
        }

        //public IQueryable<Sale> InserirDelivery(int saleId, DeliveryDTO deliveryDTO)
        //{
        //    var sale = _contexto.Sales.Where(s => s.Id == saleId);
        //    return sale;


        //}

        void ISaleRepositorio.InserirDelivery(int saleId, DeliveryDTO deliveryDTO)
        {
            throw new NotImplementedException();
        }

      
    }
}
