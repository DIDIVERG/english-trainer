
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace english_trainer_dal.Models;

public class Media : Base
{
    public string Name { get; set; } 
    [Required]
    public string VideoCode { get; set; } 
    [Required]
    public string FilePath { get; set; } 
    [Required]
    public string Subtitless { get; set; }
    
    [InverseProperty(nameof(AccountInfo.Medias))]
    [JsonIgnore]
    public virtual List<AccountInfo> AccountInfos { get; set; } = new List<AccountInfo>();
}