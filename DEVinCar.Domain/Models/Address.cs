using DEVinCar.Domain.DTOs;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DEVinCar.Domain.Models
{
    public class Address
    {
        public int Id { get; internal set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public virtual City City { get; set; }

        public virtual List<Delivery> Deliveries {get; set;}

        public Address()
        {
        }

        public Address(AddressDTO address)
        {
            Street = address.Street;
            Cep = address.Cep;
            Number = address.Number;
            Complement = address.Complement;
        }

        public void Update(AddressDTO address)
        {
            Street = address.Street;
            Cep = address.Cep;
            Number = address.Number;
            Complement = address.Complement;

        }

        public Address(AddressPatchDTO addressPatch)
        {
            Street = addressPatch.Street;
            Cep = addressPatch.Cep;
            Number = addressPatch.Number;
            Complement = addressPatch.Complement;
        }
        public void Update(AddressPatchDTO addressPatch)
        {
            Street = addressPatch.Street;
            Cep = addressPatch.Cep;
            Number = addressPatch.Number;
            Complement = addressPatch.Complement;

        }
    }
}