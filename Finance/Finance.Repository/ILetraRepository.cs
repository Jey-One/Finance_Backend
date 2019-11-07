using System;
using Finance.Entity;
using System.Collections.Generic;

namespace Finance.Repository
{
    public interface ILetraRepository: IRepository<Letra>
    {
        IEnumerable<Letra> GetLetrasByUserId(int userId);
    }
}