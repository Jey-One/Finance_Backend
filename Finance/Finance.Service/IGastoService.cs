using System;
using Finance.Entity;
using System.Collections.Generic;

namespace Finance.Service
{
    public interface IGastoService: IService<Gasto>
    {
         IEnumerable<Gasto> GetAllGastosInicialesByUserId(int letraId);
         IEnumerable<Gasto> GetAllGastosFinalesByUserId(int letraId);
    }
}