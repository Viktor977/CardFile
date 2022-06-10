using CardFile.DAL.Interfaces;
using CardFile.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.DAL.Data
{
   public class CardFileDIConfiguration
    {
        public static void ConfigureServices(IServiceCollection servicecollection)
        {
            servicecollection.AddScoped<CardFileDBContext>();
            servicecollection.AddScoped<IUnitOfWork, UnitOfWork>();
            servicecollection.AddScoped<IUserRepository, UserRepository>();
            servicecollection.AddScoped<IUserProfileRepository, UserProfileRepository>();
            servicecollection.AddScoped<ITextMaterialRepository, TextMaterialRepository>();
            servicecollection.AddScoped<IReactionRepository, ReactionRepository>();
            servicecollection.AddScoped<IHistoryRepository, HistoryRepository>();
        }
    }
}
