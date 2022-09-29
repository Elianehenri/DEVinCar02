
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICarRepositorio 
    {

        IList<Car> ObterTodos();
        Car ObterPorId ( int id );
        void Inserir(Car car);
        void Excluir(Car car);
        void Atualizar(Car car);
        List<Car> ObterPorNome(string nome);


    }
}
