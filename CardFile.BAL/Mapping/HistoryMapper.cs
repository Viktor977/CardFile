using AutoMapper;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Mapping
{
    public class HistoryMapper : Profile
    {
        public HistoryMapper()
        {
            CreateMap<History, HistoryDto>().ReverseMap();
        }
    }
}
