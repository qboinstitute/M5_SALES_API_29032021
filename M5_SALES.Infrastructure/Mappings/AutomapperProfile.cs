using AutoMapper;
using M5_SALES.Core.DTOs;
using M5_SALES.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_SALES.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerCityDTO>();
            CreateMap<CustomerCityDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();
            CreateMap<CustomerPostDTO, Customer>();

            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO, Users>();
        }


    }
}
