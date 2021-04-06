using M5_SALES.Core.Entities;
using M5_SALES.Core.Exceptions;
using M5_SALES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_SALES.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Users> ValidateUser(string userName, string password)
        {
            var user = await _usersRepository.Authentication(userName, password);
            if (user == null)
                throw new GeneralException("Usuario o Clave no son correctos");
            return user;
        }


    }
}
