
using english_trainer_dal.Models;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.DAL.Extensions;

public static class ModelBuilderExtension
{

    public static void ConfigureLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Languages>().Property(p => p.Id).HasColumnName("language_id");
    }
    public static void ConfigureMedia(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Media>().Property(p => p.Id).HasColumnName("media_id");
  
    }
    public static void ConfigurePartOfSpeech(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PartOfSpeech>().Property(p => p.Id).HasColumnName("part_of_speech_id");

    }
    public static void ConfigureTranslation(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translations>().Property(p => p.Id).HasColumnName("translation_id");
 
    }
    public static void ConfigureWords(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Words>().Property(p => p.Id).HasColumnName("word_id");
    }
}