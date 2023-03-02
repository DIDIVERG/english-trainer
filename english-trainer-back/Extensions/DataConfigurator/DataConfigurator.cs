using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository;
using english_trainer_dal.DAL.Repository.Interfaces;
using english_trainer_dal.DAL.UnitOfWork;
using english_trainer_dal.Models;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_back.Extensions.DataConfigurator;

public static class DataConfigurator
{

    public static IServiceCollection ConfigureData(this IServiceCollection collection, ConfigurationManager manager)
    {
        var connectionString = manager.GetConnectionString("Default");
        collection.AddDbContext<EnglishTrainerContext>(options => options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());
        collection.AddScoped<ILanguagesRepo, LanguageRepo>();
        collection.AddScoped<IMediaRepo, MediaRepo>();
        collection.AddScoped<IPartOfSpeechRepo, PartOfSpeechRepo>();
        collection.AddScoped<ITranslationRepo, TranslationRepo>();
        collection.AddScoped<IWordsRepo, WordsRepo>();
        collection.AddScoped<IAccountInfoRepo, AccountInfoRepo>();
        return collection;
    }
}