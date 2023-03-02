using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using english_trainer_back.Controllers.Base;
using english_trainer_back.DTOs;
using english_trainer_dal.DAL.Repository.Interfaces;
using english_trainer_dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace english_trainer_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : BaseCrudController<Words,WordsController>
    {
        public WordsController(IMapper mapper,IWordsRepo baseRepo, ILogger<WordsController> logger) : 
            base(mapper,baseRepo, logger)
        {
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<Languages>> UpdateOne(int id , WordsDto entity)
        {

            if (! await baseRepo.CheckExistence(id))
            {
                logger.LogError("There is no entity with received id");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                logger.LogError("Validation problem");
                return ValidationProblem(ModelState);
            }
            var entityToUpdate = mapper.Map<Words>(entity);
            try
            {
                await baseRepo.Update(entityToUpdate);
            }
            catch (Exception e)
            {
                logger.LogError(e,"An error while updating");
                return BadRequest(ModelState);
            }
            return Ok(entity);
        }
    }
}
