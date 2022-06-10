using AutoMapper;
using CardFile.BAL.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Access
{
    public class AutoMapperProfile : Profile
    {
        public IMapper Mapper { get; set; }
        public AutoMapperProfile() { }
        public IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(config =>
              {
                  config.AddProfile<UserMapper>();
                  config.AddProfile<UserProfileMapper>();
                  config.AddProfile<HistoryMapper>();
                  config.AddProfile<TextMaterialMapper>();
                  config.AddProfile<ReactionMapper>();
              });

            return configuration.CreateMapper();
        }
    }
}
