using System.Collections.Generic;
using Finance.Entity;
using Finance.Repository;

namespace Finance.Service.Implementation
{
    public class LetraService : ILetraService
    {
        private ILetraRepository letraRepository;

        public LetraService(ILetraRepository letraRepository)
        {
            this.letraRepository = letraRepository;
        }
        public bool Delete(int id)
        {
             return letraRepository.Delete(id);
        }

        public Letra Get(int id)
        {
             return letraRepository.Get(id);
        }

        public IEnumerable<Letra> GetAll()
        {
             return letraRepository.GetAll();
        }

        public IEnumerable<Letra> GetLetrasByUserId(int userId)
        {
             return letraRepository.GetLetrasByUserId(userId);
        }

        public bool Save(Letra entity)
        {
             return letraRepository.Save(entity);
        }

        public bool Update(Letra entity)
        {
            return letraRepository.Update(entity);
        }
    }
}