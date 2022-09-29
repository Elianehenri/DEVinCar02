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
        IList<State> ObterTodos();
        StateDTO ObterPorId(int id);
        void Inserir(StateDTO state);
        void Excluir(int id);
        void Atualizar(StateDTO state);
    }
}
