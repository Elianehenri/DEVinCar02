using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public  interface IUserService
    {
        IList<User> ObterTodos();
        UserDTO ObterPorId(int id);
        void Inserir(UserDTO user);
        void Excluir(int id);
        void Atualizar(UserDTO user);
       
    }
}
