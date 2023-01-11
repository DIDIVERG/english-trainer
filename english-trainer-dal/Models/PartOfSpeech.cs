using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace english_trainer_dal.Models;

public class PartOfSpeech: Base
{
    [Required]
    public string Name { get; set; }
    public string Info { get; set; }
    [Required]
    public string LanguageId { get; set; }
    [InverseProperty(nameof(Models.Languages.PartOfSpeeches))]
    public virtual List<Languages> Languages { get; set; } = new List<Languages>();
    [InverseProperty(nameof(Words.PartOfSpeeches))]
    public virtual List<Words> WordsList { get; set; } = new List<Words>();
}