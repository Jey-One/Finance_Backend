using System;
using Finance.Entity;
using System.Collections.Generic;

namespace Finance.Service
{
    public interface ILetraService : IService<Letra>
    {
         IEnumerable<Letra> GetLetrasByUserId(int userId);
    }
}