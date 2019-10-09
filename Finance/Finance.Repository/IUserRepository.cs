using Finance.Entity;
using Finance.Repository.DTO;

namespace Finance.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        UserDTO Login(string username,string password);
    } 
}