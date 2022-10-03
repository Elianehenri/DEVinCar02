using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Models
{
    public class Sale
    {
        private int saleId;
        private int carId;
        private int? amount;
        private decimal? unitPrice;

        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public virtual User UserBuyer { get; set; }
        public virtual User UserSeller { get; set; }
        public virtual List<SaleCar> Cars { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }      
        public Sale()
        {
        }

        public Sale(int id, DateTime saleDate, int buyerId, int sellerId, User userBuyer, User userSeller, List<SaleCar> cars, List<Delivery> deliveries)
        {
            Id = id;
            SaleDate = saleDate;
            BuyerId = buyerId;
            SellerId = sellerId;
            UserBuyer = userBuyer;
            UserSeller = userSeller;
            Cars = cars;
            Deliveries = deliveries;
        }

        public Sale(SaleDTO sale)
        {
            BuyerId = sale.BuyerId;
            SaleDate = sale.SaleDate;
        }

        public Sale(BuyDTO sale)
        {
            SellerId = sale.SellerId;
            SaleDate = sale.SaleDate;
        }

        public Sale(int saleId, int carId, int? amount, decimal? unitPrice)
        {
            this.saleId = saleId;
            this.carId = carId;
            this.amount = amount;
            this.unitPrice = unitPrice;
        }

        public void Update(SaleDTO sale)
        {
            BuyerId = sale.BuyerId;
            SaleDate = sale.SaleDate;
            SellerId = sale.Id;
        }
        public void Update(BuyDTO sale)
        {
            SellerId = sale.SellerId;
            SaleDate = sale.SaleDate;
            BuyerId = sale.Id;
            

        }
    }
}