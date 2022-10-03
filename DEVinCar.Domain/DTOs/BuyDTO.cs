using DEVinCar.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class BuyDTO
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "The SelleId is required.")]
        public int SellerId{ get; set; }
        public DateTime SaleDate { get; set; }

        public BuyDTO()
        {
            
        }

        public BuyDTO(Sale sale)
        {
            SellerId = sale.SellerId;
            SaleDate = sale.SaleDate;
        }
        
        
    }
}


