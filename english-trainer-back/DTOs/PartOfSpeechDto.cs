using english_trainer_dal.Models;

namespace english_trainer_back.DTOs;

public class PartOfSpeechDto : Base
{
    public string Name { get; set; }
    public string Info { get; set; }
    public string LanguageId { get; set; }
}