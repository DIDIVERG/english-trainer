using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Base;
using english_trainer_dal.DAL.Repository.Interfaces;
using english_trainer_dal.Models;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.DAL.Repository;

public class AccountInfoRepo : BaseRepo<AccountInfo>, IAccountInfoRepo
{
    public AccountInfoRepo(EnglishTrainerContext context) : base(context)
    {
    }
}