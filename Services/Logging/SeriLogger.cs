using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace english_trainer_back.Services.Logging;

public class Logger : ISeriLogger
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly string _applicationName;
    
    public Logger(ILogger _logger, IConfiguration _configuration)
    {
        this._configuration = _configuration;
        this._logger = _logger;
        _applicationName = _configuration.GetValue<string>("ApplicationName") ?? "No name";
    }

    public List<IDisposable> PushProperties(string filePath, string memberName, int lineNumber)
    {
        List<IDisposable> properties = new List<IDisposable>()
        {
            LogContext.PushProperty("LineNumber", lineNumber),
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("FilePath", filePath),
        };
        return properties;
    }

    public void Dispose(List<IDisposable> list)
    {
        foreach (var item in list)
        {
            item.Dispose();
        }
    }

    public void LogAppError(Exception ex, string message, string memberName = "", string sourceFilePath = "",
        int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(ex,message);
        Dispose(list);
    }

    public void LogAppError(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);    
    }

    public void LogAppCritical(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);
    }

    public void LogAppCritical(Exception ex, string message, string memberName = "", string sourceFilePath = "",
        int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(ex,message);
        Dispose(list);
    }

    public void LogAppInformation(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);
    }

    public void LogAppDebug(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);
    }

    public void LogAppTrace(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);
    }

    public void LogAppWarning(string message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
    {
        var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
        _logger.LogError(message);
        Dispose(list);
    }
}