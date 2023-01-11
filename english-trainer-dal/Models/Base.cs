using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.Models;

public class Base
{
    [Key]
    public int Id { get; set; }
}