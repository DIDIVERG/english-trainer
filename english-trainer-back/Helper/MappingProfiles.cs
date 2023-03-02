using AutoMapper;
using english_trainer_back.DTOs;
using english_trainer_dal.Models;

namespace english_trainer_back.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Languages, LanguagesDto>();
        CreateMap<Media, MediaDto>();
        CreateMap<Words, WordsDto>();
        CreateMap<Translations, TranslationsDto>();
        CreateMap<AccountInfo, AccountInfoDto>();
        CreateMap<AccountInfoDto, AccountInfo>();
        CreateMap<TranslationsDto, Translations>();
        CreateMap<WordsDto, Words>();
        CreateMap<MediaDto, Media>();
        CreateMap<LanguagesDto, Languages>();
    }
}