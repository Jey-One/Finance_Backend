using System.Collections.Generic;
using Finance.Entity;
using Finance.Repository;

namespace Finance.Service.Implementation
{
    public class GastoService : IGastoService
    {
        private IGastoRepository gastoRepository;

        public GastoService(IGastoRepository gastoRepository)
        {
            this.gastoRepository = gastoRepository;
        }
        public bool Delete(int id)
        {
            return gastoRepository.Delete(id);
        }

        public Gasto Get(int id)
        {
            return gastoRepository.Get(id);
        }

        public IEnumerable<Gasto> GetAll()
        {
            return gastoRepository.GetAll();
        }

        public IEnumerable<Gasto> GetAllGastosFinalesByUserId(int letraId)
        {
            return gastoRepository.GetAllGastosFinalesByUserId(letraId);
        }

        public IEnumerable<Gasto> GetAllGastosInicialesByUserId(int letraId)
        {
            return gastoRepository.GetAllGastosInicialesByUserId(letraId);
        }

        public bool Save(Gasto entity)
        {
            return gastoRepository.Save(entity);
        }

        public bool Update(Gasto entity)
        {
            return gastoRepository.Update(entity);
        }
    }
}