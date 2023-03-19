using YoutubeExplode.Videos.Streams;

namespace english_trainer_back.Services.YouTubeDownloader.Interfaces;

public interface IYouTubeDownloader
{
    public Task DownloadVideoAsync( string path);
    public Task DownloadVideoWithMaxResolutionAsync(string path);
    public Task DownloadClosedCaptionsAsync(string path, string language);
}