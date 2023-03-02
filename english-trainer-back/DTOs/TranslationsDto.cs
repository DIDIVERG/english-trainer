using english_trainer_dal.Models;

namespace english_trainer_back.DTOs;

public class TranslationsDto: Base
{
    public string TranslationCode { get; set; } // like en-de, en-ru 
    public string Translation { get; set; }
}