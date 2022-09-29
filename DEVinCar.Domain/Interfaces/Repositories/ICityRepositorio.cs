using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICityRepositorio
    {
        IList<City> ObterTodos();
        City ObterPorId(int id);
        void Inserir(City city);
        void Excluir(City city);
        void Atualizar(City city);

    }
}
