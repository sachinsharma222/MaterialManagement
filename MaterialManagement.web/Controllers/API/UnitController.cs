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
    public class UnitController : ControllerBase
    {

        private readonly ILogger<UnitController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public UnitController(MastersFactory mFactory, ILogger<UnitController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<UnitVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetUnitRepo.Get();
                var model = mapper.Map<UnitVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<UnitVM> Get(int id)
        {
            try
            {
                Unit data = null;
                data = _mFactory.GetUnitRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<UnitVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult<Unit> Post([FromBody] UnitVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<Unit>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetUnitRepo.Add(entity);
                _mFactory.GetUnitRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Unit> Put(int id, [FromBody] UnitVM model)
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
                var entity = mapper.Map<Unit>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetUnitRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<Unit> Delete(UnitVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetUnitRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetUnitRepo.Delete(entity))
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
