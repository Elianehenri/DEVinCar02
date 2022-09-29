using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepositorio _adressRepositorio;

        public AddressService(IAddressRepositorio adressRepositorio)
        {
            _adressRepositorio = adressRepositorio;
        }

        public void Atualizar(AdressDTO adress)
        {
            var adressDb = _adressRepositorio.ObterPorId(adress.Id);
            adressDb.Update(adress);
            _adressRepositorio.Atualizar(adressDb);
        }

        public void Excluir(int id)
        {
            var adress = _adressRepositorio.ObterPorId(id);
            _adressRepositorio.Atualizar(adress);
        }

        public void Inserir(AdressDTO adress)
        {
            _adressRepositorio.Inserir(new Address(adress));
        }


        public AdressDTO ObterPorId(int id)
        {
            return new AdressDTO(_adressRepositorio.ObterPorId(id));
        }

        public IList<Address> ObterTodos()
        {
            return _adressRepositorio.ObterTodos();
        }
    }
}


