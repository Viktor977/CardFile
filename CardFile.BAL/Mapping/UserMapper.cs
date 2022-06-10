using AutoMapper;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Mapping
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
