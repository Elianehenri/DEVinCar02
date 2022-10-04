using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IUserRepositorio
    {
        IList<User> ObterPorNome(string nome);
        User ObterPorId(int id);
        void Inserir(User user);
        void Excluir(User user);
        void Atualizar(User user);
        IQueryable<User> Query ();
        public User ObterPorLogin(string email, string password);

        public User ObterPorEmail(string email);

    }
}
