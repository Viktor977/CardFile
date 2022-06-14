using AutoMapper;
using CardFile.BAL.Interfaces;
using CardFile.BAL.Mapping;
using CardFile.BAL.Services;
using CardFile.DAL.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.Access
{
    /// <summary>
    /// 
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
