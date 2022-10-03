using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.DTOs
{
    public class AddressDTO
    {
       // public int Id { get; set; }
        [Required(ErrorMessage = "The Street is required")]
        [MaxLength(150, ErrorMessage = "Street name must be a maximum of 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The Cep is required")]
        [MaxLength(8, ErrorMessage = "The CEP must have a maximum of 8 characters")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "The Number is required")]
        public int Number { get; set; }
        [MaxLength(255, ErrorMessage = "The Complement must have a maximum of 255 characters")]
        public string Complement { get; set; }

        public AddressDTO()
        {

        }

        public AddressDTO(string street, string cep, int number, string complement)
        {

            Street = street;
            Cep = cep;
            Number = number;
            Complement = complement;
        }

        public AddressDTO(Address adress)
        {
            Street = adress.Street;
            Cep = adress.Cep;
            Number = adress.Number;
            Complement = adress.Complement;
        }
    }
}
