using YoutubeExplode.Videos;

namespace english_trainer_back.Services.Models;

public class VideoInfo
{
    public string? Quality { get; set; }
    public string? Title { get; set; }
    public string? VideoIdRaw { get; set; }
    public string? Format { get; set; }
}