using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace english_trainer_dal.Models;

public class Languages : Base
{
    [Required]
    public string FullName { get; set; }  
    [InverseProperty(nameof(PartOfSpeech.Languages))]
    [JsonIgnore]

    public virtual List<PartOfSpeech> PartOfSpeeches { get; set; } = new List<PartOfSpeech>();
}