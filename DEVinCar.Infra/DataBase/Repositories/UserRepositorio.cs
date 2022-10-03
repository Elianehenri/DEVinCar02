using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class UserRepositorio : BaseRepositorio<User, int>, IUserRepositorio
    {
        public UserRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
        }

        public IList<User> ObterPorNome(string nome)
        {
            return _contexto.Users.Where(u => u.Name == nome).ToList();
        }

        public User ObterPorEmail(string email)
        {
            return _contexto.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
