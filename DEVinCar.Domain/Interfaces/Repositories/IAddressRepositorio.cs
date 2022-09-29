
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public  interface IAddressRepositorio
    {
        IList<Address> ObterTodos();//GetAll
        Address ObterPorId(int id);//getById
        void Inserir(Address adress);//insert
        void Excluir(Address adress);//delete
        void Atualizar(Address adress);//update
    }
}
