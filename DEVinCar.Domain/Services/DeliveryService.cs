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
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliverRepositorio _deliverRepositorio;

        public DeliveryService(IDeliverRepositorio deliverRepositorio)
        {
            _deliverRepositorio = deliverRepositorio;
        }

        public void Atualizar(DeliveryDTO delivery)
        {
            var deliveryDb = _deliverRepositorio.ObterPorId(delivery.Id);
            deliveryDb.Update(delivery);
            _deliverRepositorio.Atualizar(deliveryDb);
        }

        public void Excluir(int id)
        {
            var delivery = _deliverRepositorio.ObterPorId(id);
            _deliverRepositorio.Atualizar(delivery);
        }

        public void Inserir(DeliveryDTO delivery)
        {
            _deliverRepositorio.Inserir(new Delivery(delivery));
        }

        public DeliveryDTO ObterPorId(int id)
        {
            return new DeliveryDTO(_deliverRepositorio.ObterPorId(id));
        }

        public IList<Delivery> ObterTodos()
        {
            return _deliverRepositorio.ObterTodos();
        }

    
    }
}
