using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class AddressPatchService : IAddressPatchService
    {
        private readonly IAddressPatchRepositorio _addressPatchRepositorio;
        private readonly IAddressRepositorio _addressRepositorio;

        public AddressPatchService(IAddressPatchRepositorio addressPatchRepositorio, IAddressRepositorio addressRepositorio)
        {
            _addressPatchRepositorio = addressPatchRepositorio;
            _addressRepositorio = addressRepositorio;
        }

        public void Atualizar(AddressPatchDTO adressPatch)
        {
            //var adressPatchDb = _addressPatchRepositorio.ObterPorId(adressPatch.Id);
            //adressPatchDb.Update(adressPatch);
            //_addressPatchRepositorio.Atualizar(adressPatchDb);
        }

        public void Excluir(int id)
        {
            var adressPatch = _addressPatchRepositorio.ObterPorId(id);

            _addressPatchRepositorio.Excluir(adressPatch);
        }

        public void Inserir(AddressPatchDTO adressPatch)
        {
            _addressPatchRepositorio.Inserir(new Address(adressPatch));
        }

        public AddressPatchDTO ObterPorId(int id)
        {
            return new AddressPatchDTO(_addressPatchRepositorio.ObterPorId(id));
        }

        public IList<Address> ObterTodos(
            int addressId,
            AddressPatchDTO addressPatchDTO)
        {
            Address address = (Address)_addressPatchRepositorio;
            //.Include(a => a.City)
            // .FirstOrDefault(a => a.Id == addressId);

            var query = _addressPatchRepositorio.Query();

            if (address == null)
                throw new NaoExisteException($"The address with ID: {addressId} not found.");

            string street = addressPatchDTO.Street ?? null;
            string cep = addressPatchDTO.Cep ?? null;
            string complement = addressPatchDTO.Complement ?? null;

            if (street != null)
            {
                if (addressPatchDTO.Street == "")
                    throw new Exception("The street name cannot be empty.");
                address.Street = street;
            }

            if (addressPatchDTO.Cep != null)
            {
                if (addressPatchDTO.Cep == "")
                    throw new Exception("The cep cannot be empty.");
                if (!addressPatchDTO.Cep.All(char.IsDigit))
                    throw new Exception("Every characters in cep must be numeric.");
                address.Cep = cep;
            }

            if (addressPatchDTO.Complement != null)
            {
                if (addressPatchDTO.Complement == "")
                    throw new Exception("The complement cannot be empty.");
                address.Complement = complement;
            }

            if (addressPatchDTO.Number != 0)
                address.Number = addressPatchDTO.Number;



            AddressViewModel addressViewModel = new AddressViewModel(
                address.Id,
                address.Street,
                address.CityId,
                address.City.Name,
                address.Number,
                address.Complement,
                address.Cep
            );

            return ((IList<Address>)addressViewModel);

        }
    }
}
