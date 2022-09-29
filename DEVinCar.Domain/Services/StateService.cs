using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using System;
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

        public StateService(IStateRepositorio stateRepositorio)
        {
            _stateRepositorio = stateRepositorio;
        }

        public void Atualizar(StateDTO state)
        {
            var stateDb = _stateRepositorio.ObterPorId(state.Id);
            stateDb.Update(state);
            _stateRepositorio.Atualizar(stateDb);
        }

        public void Excluir(int id)
        {
            var state = _stateRepositorio.ObterPorId(id);
            _stateRepositorio.Excluir(state);
        }

        public void Inserir(StateDTO state)
        {
            _stateRepositorio.Inserir(new State(state));
        }

        public StateDTO ObterPorId(int id)
        {
            return new StateDTO(_stateRepositorio.ObterPorId(id));
        }

        public IList<State> ObterTodos()
        {
            return _stateRepositorio.ObterTodos();  
        }
    }
}
