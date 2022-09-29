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
    public class AddressPatchService: IAddressPatchService
    {
        private readonly IAddressPatchRepositorio _addressPatchRepositorio;

        public AddressPatchService(IAddressPatchRepositorio addressPatchRepositorio)
        {
            _addressPatchRepositorio = addressPatchRepositorio;
        }

        public void Atualizar(AddressPatchDTO adressPatch)
        {
            var adressPatchDb = _addressPatchRepositorio.ObterPorId(adressPatch.Id);
            adressPatchDb.Update(adressPatch);
            _addressPatchRepositorio.Atualizar(adressPatchDb);
        }

        public void Excluir(int id)
        {
            var adressPatch = _addressPatchRepositorio.ObterPorId(id);
            
            _addressPatchRepositorio.Excluir(adressPatch);
        }

        public void Inserir(AddressPatchDTO adressPatch)
        {
            _addressPatchRepositorio.Inserir(new Address(adressPatch));
        }

        public AddressPatchDTO ObterPorId(int id)
        {
            return new AddressPatchDTO(_addressPatchRepositorio.ObterPorId(id));
        }

        public IList<Address> ObterTodos()
        {
            return _addressPatchRepositorio.ObterTodos();
        }
    }
}
