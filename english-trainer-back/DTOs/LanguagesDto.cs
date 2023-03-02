using english_trainer_dal.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace english_trainer_back.DTOs;

public class LanguagesDto : Base
{
    public string FullName { get; set; }  
}