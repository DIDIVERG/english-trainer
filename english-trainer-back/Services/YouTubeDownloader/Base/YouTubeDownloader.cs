using english_trainer_back.Services.Models;
using english_trainer_back.Services.YouTubeDownloader.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.ClosedCaptions;
using YoutubeExplode.Videos.Streams;

namespace english_trainer_back.Services.YouTubeDownloader.Base;

public class YouTubeDownloader : IYouTubeDownloader
{
    private readonly YoutubeClient _youtube;
    private IVideoStreamInfo _videoStreamInfo;
    private Manifests _manifests;
    private VideoInfo _videoInfo;
    private string _uri;
    private VideoId _id; 
    public string Uri
    { 
        get => _uri;
        set
        {
            _uri = value;
            _id = VideoId.Parse(_uri);
        }
    }
    public VideoInfo VideoInfo { get; set; }
    public CaptionsInfo CaptionsInfo { get; set; }
    public  YouTubeDownloader(string uri, string quality)
    {
        _uri = uri;
        _youtube = new YoutubeClient();
        _manifests = new Manifests();
        _videoInfo = new VideoInfo() { Quality = quality }; 
        _id = VideoId.Parse(_uri);
        
    }

    private string NormalizePath(string path)
    {
        return path + $"/{_videoInfo.Title}.{_videoInfo.Format}";
    }
    public async Task DownloadVideoAsync( string path)
    {
        IEnumerable<MuxedStreamInfo> muxedStreamInfos = _manifests.StreamManifest.GetMuxedStreams().ToList();
        if (muxedStreamInfos.Any(s => s.VideoQuality.Label == _videoInfo.Quality) is false)
        {
            var audioStreamInfo = _manifests.StreamManifest.GetAudioOnlyStreams().TryGetWithHighestBitrate();
             await DownloadWithAdaptiveStreams(_videoStreamInfo,audioStreamInfo,path);
            
        }
        MuxedStreamInfo streamInfo = muxedStreamInfos.First(i => 
            i.VideoQuality.Label == _videoInfo.Quality);
        await _youtube.Videos.Streams.DownloadAsync(streamInfo,NormalizePath(path));
    }

    public async Task InitAsync()
    {
        var result = await _youtube.Search.GetVideosAsync(_uri).ToListAsync();
        _manifests.StreamManifest = await _youtube.Videos.Streams.GetManifestAsync(_id);
        _videoStreamInfo = _manifests.StreamManifest.GetVideoOnlyStreams().First(i 
            => i.VideoQuality.Label == _videoInfo.Quality);
        _videoInfo =  new VideoInfo()
        {
            Quality = _videoStreamInfo.VideoQuality.Label,
            Format = _videoStreamInfo.Container.Name,
            Title = result.Select(i => i.Title).ToString(),
            VideoIdRaw = _id.Value
        };
        _manifests.ClosedCaptionManifest = await _youtube.Videos.ClosedCaptions.GetManifestAsync(_id);
    }
    private async Task DownloadWithAdaptiveStreams(IVideoStreamInfo videoStreamInfo, IStreamInfo? audioStreamInfo
    ,string path)
    {
        var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
        await _youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(NormalizePath(path))
            .Build());
    }
    
    public async Task DownloadVideoWithMaxResolutionAsync(string path)
    {
        IVideoStreamInfo videoStreamInfo =
            _manifests.StreamManifest.GetVideoOnlyStreams().OrderByDescending(i
                => i.VideoQuality.Label).First();
        var audioStreamInfo = _manifests.StreamManifest.GetAudioOnlyStreams().TryGetWithHighestBitrate();
         await DownloadWithAdaptiveStreams(videoStreamInfo, audioStreamInfo, path);
    }

    public async Task DownloadClosedCaptionsAsync(string path, string language)
    {
        var trackInfo = _manifests.ClosedCaptionManifest.GetByLanguage(language);
        await _youtube.Videos.ClosedCaptions.DownloadAsync(trackInfo, path + $"{_videoInfo.Title}.srt");
    }
}