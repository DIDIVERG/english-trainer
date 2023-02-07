using english_trainer_dal.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace english_trainer_dal.DAL;

public class EnglishTrainerContextFactory : IDesignTimeDbContextFactory<EnglishTrainerContext>
{
    private string connectionString;
    public string ConnectionString { get; set; }
    public EnglishTrainerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EnglishTrainerContext>();
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        return new EnglishTrainerContext(optionsBuilder.Options);
    }
}