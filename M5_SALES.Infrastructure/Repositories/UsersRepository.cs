using M5_SALES.Core.Interfaces;
using M5_SALES.Core.Entities;
using M5_SALES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_SALES.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SalesContext _context;

        public UsersRepository(SalesContext context)
        {
            _context = context;

        }


        public async Task<Users> Authentication(string userName, string password)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(x => x.Username == userName &&
                                    x.Password == password);
            return user;
        }
       
    }
}
