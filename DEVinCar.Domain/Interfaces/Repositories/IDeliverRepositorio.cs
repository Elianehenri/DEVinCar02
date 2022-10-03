using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IDeliverRepositorio
    {
        IList<Delivery> ObterTodos();
        Delivery  ObterPorId(int id);
        IQueryable<Delivery> Query();
    }
}
