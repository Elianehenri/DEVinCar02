
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICarRepositorio 
    {

        IList<Car> ObterTodos();
        List<Car> ObterPorNome(string nome);
        Car ObterPorId ( int id );
        void Inserir(Car car);
        void Excluir(Car car);
        void Atualizar(Car car);
        IQueryable<Car> Query();



    }
}
