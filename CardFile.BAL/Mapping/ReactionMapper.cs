using AutoMapper;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Mapping
{
   public  class ReactionMapper : Profile
    {
        public ReactionMapper()
        {
            CreateMap<Reaction, ReactionDto>().ReverseMap();
        }
    }
}
