using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICityRepositorio
    {
        IList<City> ObterTodos();
        IList<City> ObterPorNomeCity(int stateId, string? name);
        City ObterPorId(int id);
        void Inserir(City city);
        void Excluir(City city);
        void Atualizar(City city);
        IQueryable<City> Query();

    }
}
