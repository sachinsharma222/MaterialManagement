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
    public class StateController : ControllerBase
    {
        private readonly ILogger<StateController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public StateController(MastersFactory mFactory, ILogger<StateController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<StateVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetStateRepo.Get();
                var model = mapper.Map<StateVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<StateVM> Get(int id)
        {
            try
            {
                State data = null;
                data = _mFactory.GetStateRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<StateVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult<State> Post([FromBody] StateVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<State>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetStateRepo.Add(entity);
                _mFactory.GetStateRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<State> Put(int id, [FromBody] StateVM model)
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
                var entity = mapper.Map<State>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetStateRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<State> Delete(StateVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetStateRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetStateRepo.Delete(entity))
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
