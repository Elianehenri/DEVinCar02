using DEVinCar.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The BuyerId is required.")]
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }

        public SaleDTO()
        {
        }

   

        public SaleDTO(Sale sale)
        {

            BuyerId = sale.BuyerId;
            SaleDate = sale.SaleDate;

        }
    }
}
