using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Models
{
    public class SaleCar
    {
        public int Id { get;  set; }
        public decimal UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }
        public virtual Car Car { get; set; }
        public virtual Sale Sale { get; set; }
        public SaleCar()
        {
        }

        public SaleCar( decimal unitPrice, int? amount, int carId, int saleId)
        {
            
            UnitPrice = unitPrice;
            Amount = amount;
            CarId = carId;
            SaleId = saleId;
        }

        public SaleCar(SaleCarDTO saleCar)
        {
            CarId = saleCar.CarId;
            UnitPrice = (decimal)saleCar.UnitPrice;
            Amount = saleCar.Amount;
            SaleId = saleCar.SaleId;
        }

        public void Update(SaleCarDTO saleCar)
        {
            CarId = saleCar.CarId;
            UnitPrice = (decimal)saleCar.UnitPrice;
            Amount = saleCar.Amount;
            SaleId = saleCar.SaleId;
        }
        public decimal Sum(decimal UnitPrice, int? Amount)
        {
            return UnitPrice * (int)Amount;
        }
    }
}
