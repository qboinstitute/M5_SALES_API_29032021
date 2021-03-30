using AutoMapper;
using M5_SALES.Core.DTOs;
using M5_SALES.Core.Interfaces;
using M5_SALES.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M5_SALES.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Customer() 
        {
            //var context = new SalesContext()
            //var customerRepository = new CustomerRepository();
            //var customers =  await customerRepository.GetCustomer();
            var customers =  await _customerRepository.GetCustomer();

            //var customersDTO = customers.Select(x => new CustomerDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    City = x.City
            //});
            var customersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customersDTO);
        }


    }
}
