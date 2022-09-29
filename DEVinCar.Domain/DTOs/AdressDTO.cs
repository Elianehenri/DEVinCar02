using DEVinCar.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DEVinCar.Domain.DTOs
{
    public class AdressDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Street is required")]
        [MaxLength(150,ErrorMessage="Street name must be a maximum of 100 characters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The Cep is required")]
        [MaxLength(8,ErrorMessage="The CEP must have a maximum of 8 characters")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "The Number is required")]
        public int Number { get; set; }
        [MaxLength(255,ErrorMessage="The Complement must have a maximum of 255 characters")]
        public string Complement { get; set; }

        public AdressDTO()
        {

        }

        public AdressDTO(string street, string cep, int number, string complement)
        {
            
            Street = street;
            Cep = cep;
            Number = number;
            Complement = complement;
        }

        public AdressDTO(Address adress)
        {
            Street = adress.Street;
            Cep = adress.Cep;
            Number = adress.Number;
            Complement = adress.Complement;
        }
    }
}