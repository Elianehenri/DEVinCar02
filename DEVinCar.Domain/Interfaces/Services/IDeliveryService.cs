using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IDeliveryService
    {
        IList<Delivery> ObterTodos();
        DeliveryDTO ObterPorId(int id);
        void Inserir(DeliveryDTO delivery);
        void Excluir(int id);
        void Atualizar(DeliveryDTO delivery);
    }
}
