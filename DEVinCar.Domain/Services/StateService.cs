using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class StateService : IStateService
    {

        private readonly IStateRepositorio _stateRepositorio;
        private readonly ICityService _cityService;
        private readonly IAddressService _addressService;

        public StateService(IStateRepositorio stateRepositorio, ICityService cityService, IAddressService addressService)
        {
            _stateRepositorio = stateRepositorio;
            _cityService = cityService;
            _addressService = addressService;
        }






        //public void Atualizar(StateDTO state)
        //{
        //    var stateDb = _stateRepositorio.ObterPorId(state.Id);
        //    stateDb.Update(state);
        //    _stateRepositorio.Atualizar(stateDb);
        //}

        public void Excluir(int id)
        {
            var state = _stateRepositorio.ObterPorId(id);
            _stateRepositorio.Excluir(state);
        }

        public void Inserir(StateDTO state)
        {

            _stateRepositorio.Inserir(new State(state));
            
        }

        public void Inserir(CityDTO cityDTO)
        {
            _cityService.Inserir(cityDTO);
        }
        public void InserirAddress(AddressDTO addressDTO)
        {
            _addressService.Inserir(addressDTO);

        }

        public CityDTO ObterCityPorId(int stateId, int cityId)
        {

            return new CityDTO(_stateRepositorio.ObterCityPorId(stateId,cityId));
           
        }

        public StateDTO ObterPorId(int id)
        {
            
            return new StateDTO(_stateRepositorio.ObterPorId(id));
        }

        public IList<State> ObterPorNome(string name)
        {
            var query = _stateRepositorio.Query();


            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));
            }
            if (query.Any())
            {
                List<GetStateViewModel> getStateViewModels = new List<GetStateViewModel>();
                query
                   
                    .ToList().ForEach(state =>
                    {
                        GetStateViewModel getState = new GetStateViewModel(state.Id, state.Name, state.Initials);
                        state.Cities.ForEach(city =>
                        {
                            getState.Cities.Add(city.Name);
                        });
                        getStateViewModels.Add(getState);
                    });
                return (IList<State>)getStateViewModels;
            }
            return query.ToList();
        }

        public IList<City> ObterPorNomeCity(int stateId, string? name)

        {
            var state = _stateRepositorio.ObterPorId(stateId);
            var cityStates = _cityService.ObterPorNomeCity(name);


            if (state == null)
                throw new NaoExisteException("State not found.");


            if (!string.IsNullOrEmpty(name))
            {
                var cityQuery = cityStates.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));

                if (cityQuery.Count() == 0)
                {
                    throw new NaoExisteException("Not found");
                }

                var queryResponse = cityQuery
                    .Select(c => new GetCityByIdViewModel(
                        c.Id,
                        c.Name,
                        c.State.Id,
                        c.State.Name,
                        c.State.Initials))
                    .ToList();

                return (IList<City>)queryResponse;

                if (cityStates.Count() == 0)
                {
                    throw new NaoExisteException("Not found");
                }


                List<GetCityByIdViewModel> body = new();
                cityStates.ToList().ForEach(
                    c =>
                    {
                        body.Add(new GetCityByIdViewModel(
                            c.Id,
                            c.Name,
                            c.StateId,
                            c.State.Name,
                            c.State.Initials
                            ));

                    }
                    );

                return (IList<City>)body;

            }
            return ObterPorNomeCity( stateId, name);
             
        }

        
    }
}
