using english_trainer_dal.Models;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.DAL.Contexts;

public class EnglishTrainerContext : DbContext
{
    public DbSet<AccountInfo> AccountInfos { get; set; }
    public DbSet<Languages> Languages { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<PartOfSpeech> PartOfSpeeches { get; set; }
    public DbSet<Words> Words { get; set; }
    public DbSet<Translations> Translations { get; set; }

    public EnglishTrainerContext(DbContextOptions<EnglishTrainerContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // использование Fluent API
        base.OnModelCreating(modelBuilder);
    }
    
}