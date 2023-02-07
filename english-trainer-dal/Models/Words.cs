
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace english_trainer_dal.Models;

public class Words : Base
{
    [Required]
    public string Word { get; set; }
    public string Transcription { get; set; }
    [InverseProperty(nameof(Words.PartOfSpeeches))]
    public virtual List<PartOfSpeech> PartOfSpeeches { get; set; } = new List<PartOfSpeech>();
    [InverseProperty(nameof(Translations.WordsList))]
    public virtual List<Translations> TranslationsList { get; set; } = new List<Translations>();
}