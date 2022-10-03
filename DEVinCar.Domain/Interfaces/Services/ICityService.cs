using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICityService
    {

        IList<City> ObterPorNomeCity(string? name);//,int stateId
        IList<City> ObterTodos();
        CityDTO ObterPorId(int id);
        void Inserir(CityDTO city);
        void Excluir(int id);
        void Atualizar(CityDTO city);
    }
}
