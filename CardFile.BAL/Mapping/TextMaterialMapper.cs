using AutoMapper;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Mapping
{
    public class TextMaterialMapper : Profile
    {
        public TextMaterialMapper()
        {
            CreateMap<TextMaterial, TextMaterialDto>().ReverseMap();
        }
    }
}
