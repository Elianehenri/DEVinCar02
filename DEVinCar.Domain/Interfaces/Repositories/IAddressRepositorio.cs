
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public  interface IAddressRepositorio
    {
        IList<Address> ObterTodos();
        Address ObterPorId(int id);
        void Excluir(Address adress);
        void Inserir(Address adress);
        IQueryable<Address> Query();
    }
}
