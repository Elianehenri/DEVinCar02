using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IUserRepositorio
    {
        List<User> ObterPorNome(string nome);
        IList<User> ObterTodos();
        User ObterPorId(int id);
        void Inserir(User user);
        void Excluir(User user);
        void Atualizar(User user);

    }
}
