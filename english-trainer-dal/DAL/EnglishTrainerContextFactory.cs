using english_trainer_dal.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;

namespace english_trainer_dal.DAL;

public class EnglishTrainerContextFactory : IDesignTimeDbContextFactory<EnglishTrainerContext>
{
    private string connectionString;
    public string ConnectionString { get; set; }
    public EnglishTrainerContext CreateDbContext(string[] args)
    {
        NpgsqlConnectionStringBuilder connectionString = new NpgsqlConnectionStringBuilder()
        {
            
            Host = "localhost",
            Port = 49153, 
            Database = "english_trainer_db",
            Username = "postgres"
        };
        
        var optionsBuilder = new DbContextOptionsBuilder<EnglishTrainerContext>();
        optionsBuilder.UseNpgsql(connectionString.ConnectionString).UseSnakeCaseNamingConvention();
        return new EnglishTrainerContext(optionsBuilder.Options);
    }
}