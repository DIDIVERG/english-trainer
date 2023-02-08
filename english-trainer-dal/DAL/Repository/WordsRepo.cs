using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Base;
using english_trainer_dal.DAL.Repository.Interfaces;
using english_trainer_dal.Models;

namespace english_trainer_dal.DAL.Repository;

public class WordsRepo: BaseRepo<Words>,IWordsRepo
{
    public WordsRepo(EnglishTrainerContext context) : base(context)
    {
        
    }
}