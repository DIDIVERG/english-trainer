using english_trainer_dal.Models;

namespace english_trainer_back.DTOs;

public class AccountInfoDto : Base
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Mail { get; set; }
    public string DisplayName { get; set; }  // name that will display in profile
    public string LanguageCode { get; set; }  // the language user want to learn
}