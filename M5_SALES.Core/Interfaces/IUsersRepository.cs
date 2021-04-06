using M5_SALES.Core.Entities;
using System.Threading.Tasks;

namespace M5_SALES.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Authentication(string userName, string password);
    }
}