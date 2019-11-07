using System;
using Finance.Entity;
using System.Collections.Generic;

namespace Finance.Repository
{
    public interface IGastoRepository : IRepository<Gasto>
    {
         IEnumerable<Gasto> GetAllGastosInicialesByUserId(int letraId);
         IEnumerable<Gasto> GetAllGastosFinalesByUserId(int letraId);
    }
}