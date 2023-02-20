using english_trainer_dal.DAL.Repository.Interfaces;

namespace english_trainer_dal.DAL.Repository.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ILanguagesRepo LanguagesRepo { get; }
    IMediaRepo MediaRepo { get; }
    IPartOfSpeechRepo PartOfSpeechRepo { get; }
    ITranslationRepo TranslationRepo { get; }
    IWordsRepo WordsRepo { get; } 
    Task<int> SaveChangesAsync();
}