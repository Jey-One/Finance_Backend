using Finance.Entity;
using Finance.Repository.DTO;

namespace Finance.Service
{
    public interface IUserService: IService<User>
    {
        UserDTO Login(string username,string password);
    }
}