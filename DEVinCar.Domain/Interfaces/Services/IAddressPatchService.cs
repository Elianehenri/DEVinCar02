using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IAddressPatchService
    {
        IList<Address> ObterTodos();
        AddressPatchDTO ObterPorId(int id);
        void Inserir(AddressPatchDTO adressPatch);
        void Excluir(int id);
        void Atualizar(AddressPatchDTO adressPatch);
    }
}
