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
    public class PartOfSpeechController : BaseCrudController<PartOfSpeech,PartOfSpeechController>
    {
        public PartOfSpeechController(IMapper mapper,IBaseRepo<PartOfSpeech> baseRepo, 
            ILogger<PartOfSpeechController> logger) : 
            base(mapper,baseRepo, logger)
        {
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<Languages>> UpdateOne(int id , PartOfSpeechDto entity)
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
            var entityToUpdate = mapper.Map<PartOfSpeech>(entity);
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