using AutoMapper;
using DAL.Repos.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialManagement.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public ProjectController(MastersFactory mFactory, ILogger<ProjectController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<ProjectVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetProjectRepo.Get();
                var model = mapper.Map<ProjectVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<ProjectVM> Get(int id)
        {
            try
            {
                Project data = null;
                data = _mFactory.GetProjectRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<ProjectVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult<Project> Post([FromBody] ProjectVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<Project>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetProjectRepo.Add(entity);
                _mFactory.GetProjectRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Project> Put(int id, [FromBody] ProjectVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != model.Id)
            {
                return BadRequest("Id did not match");
            }

            if (model == null)
                return NotFound();

            try
            {
                var entity = mapper.Map<Project>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetProjectRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<Project> Delete(ProjectVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetProjectRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetProjectRepo.Delete(entity))
                    return Ok();

                return NotFound("Data not updated");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }



    }
}
