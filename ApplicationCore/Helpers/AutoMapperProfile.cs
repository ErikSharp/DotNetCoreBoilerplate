using ApplicationCore.Models;
using dto = ApplicationCore.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<dto.UserIn, User>();
            CreateMap<User, dto.UserOut>();
        }
    }
}
