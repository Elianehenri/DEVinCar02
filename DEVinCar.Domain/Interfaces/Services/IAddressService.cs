using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Services
{
    public  interface IAddressService
    {
        IList<Address> ObterTodos();
        AdressDTO ObterPorId(int id);
        void Inserir(AdressDTO adress);
        void Excluir(int id);
        void Atualizar(AdressDTO adress);
    }
}
