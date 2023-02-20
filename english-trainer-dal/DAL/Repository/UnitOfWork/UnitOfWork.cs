﻿using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Interfaces;

namespace english_trainer_dal.DAL.Repository.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly EnglishTrainerContext _context;
    private bool _disposed;
    public UnitOfWork(EnglishTrainerContext context)
    {
        _context = context;
        LanguagesRepo = new LanguageRepo(_context);
        MediaRepo = new MediaRepo(_context);
        PartOfSpeechRepo = new PartOfSpeechRepo(_context);
        WordsRepo = new WordsRepo(_context);
        TranslationRepo = new TranslationRepo(_context);
    }
    
    public void Dispose()
    {
        Dispose(true); 
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // place to releasing managed resources with dispose method 
            _context.Dispose();
        }
        // place to releasing unmanaged resources
        _disposed = true;
    }

    ~UnitOfWork() => Dispose(false);
    
    public ILanguagesRepo LanguagesRepo { get; }
    public IMediaRepo MediaRepo { get; }
    public IPartOfSpeechRepo PartOfSpeechRepo { get; }
    public ITranslationRepo TranslationRepo { get; }
    public IWordsRepo WordsRepo { get; }
    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while saving changes in database");
        }
    }
}