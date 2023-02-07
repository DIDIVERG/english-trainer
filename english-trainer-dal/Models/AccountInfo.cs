using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace english_trainer_dal.Models;

public class AccountInfo : Base
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Mail { get; set; }
    public string DisplayName { get; set; }  // name that will display in profile
    public string LanguageCode { get; set; }  // the language user want to learn
    [InverseProperty(nameof(Models.Translations.AccountInfos))]
    public virtual List<Translations> Translations { get; set; } = new List<Translations>();
    [InverseProperty(nameof(Media.AccountInfos))]
    public virtual List<Media> Medias { get; set; } = new List<Media>();
}