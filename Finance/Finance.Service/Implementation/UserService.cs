using System.Collections.Generic;
using Finance.Entity;
using Finance.Repository;
using Finance.Repository.DTO;

namespace Finance.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public UserDTO Login(string username, string password)
        {
            return userRepository.Login(username,password);
        }

        public bool Save(User entity)
        {
            return userRepository.Save(entity);
        }

        public bool Update(User entity)
        {
            return userRepository.Update(entity);
        }
    }
}