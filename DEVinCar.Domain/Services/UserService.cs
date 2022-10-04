using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositorio _userRepositorio;
        private readonly ISaleRepositorio _saleRepositorio;

        public UserService(IUserRepositorio userRepositorio, ISaleRepositorio saleRepositorio)
        {
            _userRepositorio = userRepositorio;
            _saleRepositorio = saleRepositorio;
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
            var oldUser = _userRepositorio.ObterPorEmail(user.Email);

            if (oldUser != null)
            {
                throw new JaexisteException("Email ja cadastrado.");
            }
            _userRepositorio.Inserir(new User(user));
        }

        public UserDTO ObterPorId(int id)
        {
            return new UserDTO(_userRepositorio.ObterPorId(id));
        }



        public IList<User> ObterPorNome(
            string name,
            DateTime? birthDateMax,
            DateTime? birthDateMin)
        {

            var query = _userRepositorio.Query();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (birthDateMin.HasValue)
            {
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);
            }

            if (birthDateMax.HasValue)
            {
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);
            }
            return query.ToList();
   
        }


        public IList<Sale> GetByIdBuy(int id)
        {
            
            return _saleRepositorio.GetByIdBuy(id);
        }
        public IList<Sale> GetSalesBySellerId(int id)
        {
            
            return _saleRepositorio.GetSalesBySellerId(id);
        }

        public User ObterPorLogin(string email, string password)//LoginDTO loginDTO
        {
            var user = _userRepositorio.ObterPorLogin( email,  password);
                
            return user;
        }
    }
    }



