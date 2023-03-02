using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.UnitOfWork;
using english_trainer_dal.Models;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_tests.DataAccesLayerTests.RepositoryTest;

// For testing base repository opportunities we will use media repository as an example  
public class BaseRepoTests
{

    private DbContextOptionsBuilder<EnglishTrainerContext> _optionsBuilder;
    private UnitOfWork _unit;
    public BaseRepoTests()
    {
        _optionsBuilder =
            new DbContextOptionsBuilder<EnglishTrainerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
        _unit = new UnitOfWork(new EnglishTrainerContext(_optionsBuilder.Options));
    }
    [Fact]
    public async Task UnitOfTestMediaRepository_AddAsyncTest_ReturnsCreatedValue()
    {
        //arrange
        Media media = new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw231"};  
        //act
        await _unit.MediaRepo.AddAsync(media);
        await _unit.MediaRepo.SaveChangesAsync();
        Media media_get = await _unit.MediaRepo.GetOneAsync(1);
        //assert 
        media_get.FilePath.Should().Be("/path");
        media_get.Name.Should().Be("Media");
        media_get.Subtitless.Should().Be("None");
        _unit.Dispose();
    }

    [Fact]
    public async Task UnitOfTestMediaRepository_AddRangeAsyncTest_ReturnsQuantityOfAddedValues()
    {
        //arrange
        List<Media> medias = new List<Media>()
        {
            new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdADSAw23S1"},
            new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdAw231"}
        };
        Media media_test =  new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw23"};
        medias.Add(media_test);
        //act
        int count =  _unit.MediaRepo.GetAllAsync().Result.Count();
        await _unit.MediaRepo.AddRangeAsync(medias);
        await _unit.MediaRepo.SaveChangesAsync();
        List<Media> medias_get =  _unit.MediaRepo.GetAllAsync().Result.ToList();
        //assert 
        medias_get.Count().Should().Be(count+medias_get.Count());
        medias_get.Should().Contain(media_test);
        _unit.Dispose();
    }

    [Fact]
    public async Task UnitOfTestMediaRepository_GetOneAsync_ReturnsIdOfCreatedValue()
    {
        //arrange 
        List<Media> medias = new List<Media>()
        {
            new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdADSAw23S1"},
            new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdAw231"}
        };
        Media media_test =  new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw23"};
        medias.Add(media_test); 
        await _unit.MediaRepo.AddRangeAsync(medias);
        await _unit.MediaRepo.SaveChangesAsync();
        //act
        Media media = await _unit.MediaRepo.GetOneAsync(1);
        //assert
        media.VideoCode.Should().Be("sdADSAw23S1");
        _unit.Dispose();
    }

    [Fact]
    public async Task UnitOfTestMediaRepository_GetAllAsync_ReturnsAllAddedValues()
    {
        //arrange 
        List<Media> medias = new List<Media>();
        Media media_test1 =  new Media() { FilePath = "/path", Name = "Med", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test2 =  new Media() { FilePath = "/path", Name = "Mei", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test3 =  new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw23"};
        medias.Add(media_test1); 
        medias.Add(media_test2); 
        medias.Add(media_test3); 
        await _unit.MediaRepo.AddRangeAsync(medias);
        await _unit.MediaRepo.SaveChangesAsync();
        //act
        List<Media> medias_get = _unit.MediaRepo.GetAllAsync().Result.ToList();
        //assert
        medias_get.Contains(media_test1);
        medias_get.Contains(media_test2);
        medias_get.Contains(media_test3);
        medias_get.Count().Should().Be(3);
        _unit.Dispose();
    }

    [Fact]
    public async Task UnitOfTestMediaRepository_DeleteAsync_ReturnsQuantityOfElementsMinusOne()
    {
        //arrange 
        List<Media> medias = new List<Media>();
        Media media_test1 =  new Media() { FilePath = "/path", Name = "Med", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test2 =  new Media() { FilePath = "/path", Name = "Mei", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test3 =  new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw23"};
        medias.Add(media_test1); 
        medias.Add(media_test2); 
        medias.Add(media_test3); 
        await _unit.MediaRepo.AddRangeAsync(medias);
        await _unit.MediaRepo.SaveChangesAsync();
        //act
        await _unit.MediaRepo.DeleteAsync(media_test1);
        await _unit.MediaRepo.SaveChangesAsync();
        List<Media> medias_get = _unit.MediaRepo.GetAllAsync().Result.ToList();
        //assert
        medias_get.Count().Should().Be(2);
        medias_get.Should().NotContain(media_test1);
        _unit.Dispose();
    } 
    [Fact]
    public async Task UnitOfTestMediaRepository_DeleteRangeAsync_ReturnsQuantityOfElementsMinusTwo()
    {
        //arrange 
        List<Media> medias = new List<Media>();
        Media media_test1 =  new Media() { FilePath = "/path", Name = "Med", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test2 =  new Media() { FilePath = "/path", Name = "Mei", Subtitless = "None", VideoCode = "sdw23"};
        Media media_test3 =  new Media() { FilePath = "/path", Name = "Media", Subtitless = "None", VideoCode = "sdw23"};
        medias.Add(media_test1); 
        medias.Add(media_test2); 
        medias.Add(media_test3); 
        await _unit.MediaRepo.AddRangeAsync(medias);
        await _unit.MediaRepo.SaveChangesAsync();
        List<Media> medias2 = new List<Media>();
        medias2.Add(media_test1);
        medias2.Add(media_test2);
        //act
        await _unit.MediaRepo.DeleteRangeAsync(medias2);
        await _unit.MediaRepo.SaveChangesAsync();
        List<Media> medias_get = _unit.MediaRepo.GetAllAsync().Result.ToList();
        //assert
        medias_get.Count().Should().Be(1);
        medias_get.Should().NotContain(media_test1).And.NotContain(media_test2);
        _unit.Dispose();
    }
}