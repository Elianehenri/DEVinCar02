using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        IList<Address> ObterTodos(
          int? cityId,
          int? stateId,
          string street,
          string cep);
        AddressDTO ObterPorId(int id);
        void Excluir(int id);
        void Inserir(AddressDTO adress);

    }
}
