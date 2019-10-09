using System.Collections.Generic;
using Finance.Entity;
using System;
using Finance.Repository.Context;
using Finance.Repository.DTO;
using System.Linq;

namespace Finance.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                User user = Get(id);
                context.Users.Remove(user);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public User Get(int id)
        {
           var result = new User();
            try
            {
                result = context.Users.Single(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            try
            {
                result = context.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public UserDTO Login(string username, string password)
        {
            var result = new User();
            try
            {
                result = context.Users.Single(x => x.Username==username && x.Password==password);
            }
            catch (System.Exception)
            {
                return null;
            }
            if(result==null)
                return null;
            else
                return new UserDTO {
                    Id = result.Id,
                    Username=result.Username,
                    Password=result.Password,
                    Name=result.Name,
                    UrlImage = result.UrlImage
                };
        }
        // probando comentario
        // probando x2 
        public bool Save(User entity)
        {
            try
            { 
                context.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
            
        }
        public bool Update(User entity)
        {
             try
            {
                var originalUser = context.Users.Single(
                    user => user.Id == entity.Id
                );

                originalUser.Username = entity.Username;
                originalUser.Password = entity.Password;
                originalUser.Name = entity.Name;
                originalUser.UrlImage = entity.UrlImage;

                context.Update(originalUser);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}