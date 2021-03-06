using CardFile.DAL.Interfaces;
using CardFile.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CardFile.DAL.Data
{
    /// <summary>
    /// This class provided configuration DI the data layer
    /// </summary>
    public class CardFileDIDalConfiguration
    {
        public static void ConfigureServices(IServiceCollection servicecollection)
        {
            servicecollection.AddScoped<CardFileDBContext>();
            servicecollection.AddScoped<IUnitOfWork, UnitOfWork>();
            servicecollection.AddScoped<IUserRepository, UserRepository>();     
            servicecollection.AddScoped<ITextMaterialRepository, TextMaterialRepository>();
            servicecollection.AddScoped<IReactionRepository, ReactionRepository>();
            servicecollection.AddScoped<IHistoryRepository, HistoryRepository>();
        }
    }
}
