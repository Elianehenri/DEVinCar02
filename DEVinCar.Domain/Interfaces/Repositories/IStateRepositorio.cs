using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IStateRepositorio
    {
      
        IList<State> ObterPorNome(string name);//estado
        IList<City> ObterPorNomeCity(int stateId, string? name);
        State ObterPorId(int id);//get por estado
        void Inserir(State state);//post
        //void Inserir(CityDTO cityDTO);
        void Excluir(State state);
        // void Atualizar(StateDTO state);
        City ObterCityPorId(int stateId, int cityId);//get por cidade
        IQueryable<State> Query();
    }
}
