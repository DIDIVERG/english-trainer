using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace english_trainer_dal.Models;

public class Languages
{
    [Key]
    [MaxLength(3)] // something kind of ENG or DEU or something else 
    public string LanguageId { get; set; }
    [Required]
    public string FullName { get; set; }  
    [InverseProperty(nameof(PartOfSpeech.Languages))]
    public virtual List<PartOfSpeech> PartOfSpeeches { get; set; } = new List<PartOfSpeech>();
}