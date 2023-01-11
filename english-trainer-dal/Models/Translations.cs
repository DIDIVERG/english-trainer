using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace english_trainer_dal.Models;

public class Translations : Base
{
    [Required]
    public string TranslationCode { get; set; } // like en-de, en-ru 
    public string Translation { get; set; }

    [InverseProperty(nameof(AccountInfo.Translations))]
    public virtual List<AccountInfo> AccountInfos { get; set; } = new List<AccountInfo>();
    [InverseProperty(nameof(Words.TranslationsList))]
    public virtual List<Words> WordsList { get; set; } = new List<Words>();
}