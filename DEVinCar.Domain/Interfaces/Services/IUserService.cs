using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public  interface IUserService
    {
        IList<User> ObterPorNome(string name,
            DateTime? birthDateMax,
            DateTime? birthDateMin);
        UserDTO ObterPorId(int id);
        void Inserir(UserDTO user);
        void Excluir(int id);
        void Atualizar(UserDTO user);
        
        IList<Sale> GetByIdBuy(int userId);
        IList<Sale> GetSalesBySellerId(int userId);


    }
}
