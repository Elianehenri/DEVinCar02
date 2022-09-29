using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepositorio _userRepositorio;

        public UserService(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }

        public void Atualizar(UserDTO user)
        {
            var userDb = _userRepositorio.ObterPorId(user.Id);
            userDb.Update(user);
            _userRepositorio.Atualizar(userDb);
        }

        public void Excluir(int id)
        {
            var user = _userRepositorio.ObterPorId(id);
            _userRepositorio.Excluir(user);
        }

        public void Inserir(UserDTO user)
        {
            _userRepositorio.Inserir(new User(user));
        }

        public UserDTO ObterPorId(int id)
        {
            return new UserDTO(_userRepositorio.ObterPorId(id));
        }

       

        public IList<User> ObterTodos()
        {
           return _userRepositorio.ObterTodos();
        }
    }
}
