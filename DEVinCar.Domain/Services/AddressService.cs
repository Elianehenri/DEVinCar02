using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;
using System.Linq;
using System.Net;

namespace DEVinCar.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepositorio _addressRepositorio;

        public AddressService(IAddressRepositorio addressRepositorio)
        {
            _addressRepositorio = addressRepositorio;
        }


        public void Excluir(int id)
        {
            var address = _addressRepositorio.ObterPorId(id);
            _addressRepositorio.Excluir(address);
        }

        public void Inserir(AddressDTO address)
        {
            _addressRepositorio.Inserir(new Address(address));
        }

        public AddressDTO ObterPorId(int id)
        {
            return new AddressDTO(_addressRepositorio.ObterPorId(id));
        }

        public IList<Address> ObterTodos(
            int? cityId, 
            int? stateId, 
            string street, 
            string cep)
        {
            var query = _addressRepositorio.Query();

            if (cityId.HasValue)
            {
                query = query.Where(a => a.CityId == cityId);
            }
            if (stateId.HasValue)
            {
                query = query.Where(a => a.City.StateId == stateId);
            }

            if (!string.IsNullOrEmpty(street))
            {
                street = street.ToUpper();
                query = query.Where(a => a.Street.Contains(street));
            }

            if (!string.IsNullOrEmpty(cep))
            {
                query = query.Where(a => a.Cep == cep);
            }


            List<AddressViewModel> addressesViewModel = new List<AddressViewModel>();
            query
               
                .ToList().ForEach(address => {
                    addressesViewModel.Add(new AddressViewModel(address.Id,
                                                            address.Street,
                                                            address.CityId,
                                                            address.City.Name,
                                                            address.Number,
                                                            address.Complement,
                                                            address.Cep));
                });
            return ((IList<Address>)addressesViewModel);

        }
    }
}


