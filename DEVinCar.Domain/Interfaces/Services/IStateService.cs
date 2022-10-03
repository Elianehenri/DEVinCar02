using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IStateService
    {
        IList<State> ObterPorNome(string name);//estado
        IList<City> ObterPorNomeCity(int stateId, string name);
        StateDTO ObterPorId(int id);//get por estado
        void Inserir(StateDTO state);//post
        void Inserir(CityDTO cityDTO);
        public void InserirAddress(AddressDTO addressDTO);
        void Excluir(int id);
       // void Atualizar(StateDTO state);
        CityDTO ObterCityPorId(int stateId, int cityId);//get por cidade
    }
}
