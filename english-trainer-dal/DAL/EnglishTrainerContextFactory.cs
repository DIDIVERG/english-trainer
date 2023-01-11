using english_trainer_dal.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace english_trainer_dal.DAL;

public class EnglishTrainerContextFactory : IDesignTimeDbContextFactory<EnglishTrainerContext>
{
    public EnglishTrainerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EnglishTrainerContext>();
        string connectionString = ""; 
        optionsBuilder.UseNpgsql(connectionString);
        return new EnglishTrainerContext(optionsBuilder.Options);
    }
}