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
    public class DeliveryRepositorio : BaseRepositorio<Delivery, int>, IDeliverRepositorio
    {
        public DeliveryRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
        }
    }
}
