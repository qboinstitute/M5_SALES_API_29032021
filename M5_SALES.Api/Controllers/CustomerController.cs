using AutoMapper;
using M5_SALES.Core.DTOs;
using M5_SALES.Core.Entities;
using M5_SALES.Core.Exceptions;
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
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            //var context = new SalesContext()
            //var customerRepository = new CustomerRepository();
            //var customers =  await customerRepository.GetCustomer();
            var customers = await _customerService.GetCustomer();

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

        [HttpGet("{id}")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            //if (customer == null)
            //    throw new Exception("El cliente no existe");
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        //[HttpGet("CustomerByNameAndTel/{name}/{tel}")]
        [HttpGet]
        [Route("CustomerByNameAndTel/{name}/{tel}")]
        public async Task<IActionResult> CustomerByNameAndTel(string name, string tel)
        {
            int id = 1;
            var customer = await _customerService.GetCustomerById(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        //[Route("api/Customer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerPostDTO)
        {
            var customer = _mapper.Map<Customer>(customerPostDTO);
            await _customerService.InsertCustomer(customer);
            return Ok(customer);
        }

        [HttpPut]
        //[Route("api/Customer")]
        public async Task<IActionResult> PutCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.UpdateCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return Ok(result);
        }


    }
}
