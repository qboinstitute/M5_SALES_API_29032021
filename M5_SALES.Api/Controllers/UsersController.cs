using AutoMapper;
using M5_SALES.Core.DTOs;
using M5_SALES.Core.Interfaces;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet("{userName}/{password}")]
        public async Task<IActionResult> Authentication(string userName, string password)
        {
            var user = await _usersService.ValidateUser(userName, password);
            var userDTO = _mapper.Map<UsersDTO>(user);
            return Ok(userDTO);
        }




    }
}
