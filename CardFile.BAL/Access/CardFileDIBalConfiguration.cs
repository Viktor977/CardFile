using AutoMapper;
using CardFile.BAL.Interfaces;
using CardFile.BAL.Services;
using CardFile.DAL.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CardFile.BAL.Access
{
    /// <summary>
    ///  This class provided configuration DI the business layer
    /// </summary>
    public class CardFileDIBalConfiguration
    {
        public static void ConfigureServices(IServiceCollection descriptors)
        {
            CardFileDIDalConfiguration.ConfigureServices(descriptors);
            descriptors.AddScoped<IUserService, UserService>();
            descriptors.AddScoped<IUserProfileService, UserProfileService>();
            descriptors.AddScoped<ITextMaterialService, TextMaterialService>();
            descriptors.AddScoped<IHistoryService, HistoryService>();

            var profiles = new AutoMapperProfile();
            IMapper mapper = profiles.GetMapper();
            descriptors.AddSingleton(mapper);
            
        }
    }
}
