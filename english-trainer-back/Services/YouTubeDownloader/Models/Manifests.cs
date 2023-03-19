using YoutubeExplode.Videos.ClosedCaptions;
using YoutubeExplode.Videos.Streams;

namespace english_trainer_back.Services.YouTubeDownloader.Models;

public class Manifests
{
    public StreamManifest StreamManifest { get; set; }
    public ClosedCaptionManifest ClosedCaptionManifest { get; set; }
}