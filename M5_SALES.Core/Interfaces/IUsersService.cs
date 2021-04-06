using M5_SALES.Core.Entities;
using System.Threading.Tasks;

namespace M5_SALES.Core.Interfaces
{
    public interface IUsersService
    {
        Task<Users> ValidateUser(string userName, string password);
    }
}