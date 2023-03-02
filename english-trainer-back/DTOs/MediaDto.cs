using english_trainer_dal.Models;

namespace english_trainer_back.DTOs;

public class MediaDto : Base
{
    public string Name { get; set; } 
    public string VideoCode { get; set; } 
    public string FilePath { get; set; } 
    public string Subtitless { get; set; }
}