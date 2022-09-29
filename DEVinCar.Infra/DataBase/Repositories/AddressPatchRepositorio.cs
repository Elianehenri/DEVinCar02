using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;


namespace DEVinCar.Infra.DataBase.Repositories
{
    public class AddressPatchRepositorio : BaseRepositorio<Address, int>, IAddressPatchRepositorio
    {
        public AddressPatchRepositorio(DevInCarDbContext contexto) : base(contexto)
        {
        }
    }
}
