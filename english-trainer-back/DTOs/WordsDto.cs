using english_trainer_dal.Models;

namespace english_trainer_back.DTOs;

public class WordsDto : Base
{
    public string Word { get; set; }
    public string Transcription { get; set; }
}