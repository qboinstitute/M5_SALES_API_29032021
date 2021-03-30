using M5_SALES.Core.Entities;
using M5_SALES.Core.Interfaces;
using M5_SALES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_SALES.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }

        public CustomerRepository()
        {

        }


        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            //using var data = new SalesContext();
            //return await data.Customer.ToListAsync();            
            var customers = await _context.Customer.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            return customer;
        }


        public async Task InsertCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var customerNow = await GetCustomerById(customer.Id);
            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customerNow.City = customer.City;
            customerNow.Country = customer.Country;
            customerNow.Phone = customer.Phone;

            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customerNow = await GetCustomerById(id);
            _context.Customer.Remove(customerNow);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
    }
}
