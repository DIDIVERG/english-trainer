using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using english_trainer_dal.DAL.Repository.Interfaces;
using english_trainer_dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace english_trainer_back.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCrudController<TEntity,TController> : ControllerBase where TEntity:english_trainer_dal.Models.Base
        where TController : ControllerBase
    {
        protected readonly IBaseRepo<TEntity> baseRepo;
        protected readonly ILogger<TController> logger;
        protected readonly IMapper mapper;
        public BaseCrudController(IMapper mapper,IBaseRepo<TEntity> baseRepo, ILogger<TController> logger)
        {
            this.baseRepo = baseRepo;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("GetOne")]
        public async Task<ActionResult<TEntity>> GetOneAsync(int id)
        {
            var response = await baseRepo.GetOneAsync(id);
            if (response == null)
            {
                logger.LogError("There is no such entity");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                logger.LogError("There are no entities while getting one");
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var response = await baseRepo.GetAllAsync();
            return Ok(response);
        }
        
        [HttpPost("AddRange")]
        public async Task<ActionResult<IEnumerable<TEntity>>> AddRange([FromBody] IEnumerable<TEntity> entities)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError("Validation problem");
                return ValidationProblem();
            }
            try
            {
                await baseRepo.AddRangeAsync(entities);
                await baseRepo.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, $"An error occured while adding");
                return BadRequest();
            }
            return Ok(entities);
        }
        
       
        [HttpDelete("DeleteOne/{id}")]
        public async Task<ActionResult<TEntity>> DeleteOne (int id)
        {
            var response = await baseRepo.GetOneAsync(id);
            if (response == null)
            {
                logger.LogError("There is no such entity");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                logger.LogError("Validation problem");
                return ValidationProblem();
            }
            await baseRepo.DeleteAsync(response);
            await baseRepo.SaveChangesAsync();
            return Ok(response);
        }
    }
}
