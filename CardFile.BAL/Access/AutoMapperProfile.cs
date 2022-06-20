using AutoMapper;
using CardFile.BAL.Mapping;

namespace CardFile.BAL.Access
{
    public class AutoMapperProfile : Profile
    {    
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

          
            var profiles= configuration.CreateMapper();
          
            return profiles;
        }
    }
}
