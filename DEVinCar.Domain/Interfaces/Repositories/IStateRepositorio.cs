using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IStateRepositorio
    {
        IList<State> ObterTodos();
        State ObterPorId(int id);
        void Inserir(State state);
        void Excluir(State state);
        void Atualizar(State state);
    }
}
