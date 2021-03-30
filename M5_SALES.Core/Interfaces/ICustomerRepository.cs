using M5_SALES.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5_SALES.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> DeleteCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomer();
        Task<Customer> GetCustomerById(int id);
        Task InsertCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
    }
}