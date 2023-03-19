// See https://aka.ms/new-console-template for more information

using english_trainer_back.Services.YouTubeDownloader.Base;

Console.WriteLine("Hello, World!");

string uri = "https://www.youtube.com/watch?v=fzEHSF7uVA4&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=17";
YouTubeDownloader downloader = new YouTubeDownloader(uri, "144p");
await downloader.InitAsync();

await downloader.DownloadClosedCaptionsAsync("en",@"C:\Users\ILYA\Desktop\Videos");