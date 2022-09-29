﻿using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        IList<Sale> ObterTodos();
        SaleDTO ObterPorId(int id);
        void Inserir(SaleDTO sale);
        void Excluir(int id);
        void Atualizar(SaleDTO sale);
    }
}
