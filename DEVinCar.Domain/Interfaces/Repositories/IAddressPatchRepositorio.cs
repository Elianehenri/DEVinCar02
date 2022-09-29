using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
   public interface IAddressPatchRepositorio
    {
        IList<Address> ObterTodos();//GetAll
        Address ObterPorId(int id);//getById
        void Inserir(Address adress);//insert
        void Excluir(Address adress);//delete
        void Atualizar(Address adress);//update
    }
}
