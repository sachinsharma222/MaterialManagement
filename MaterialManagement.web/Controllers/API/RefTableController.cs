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
    public class RefTableController : ControllerBase
    {
        private readonly ILogger<RefTableController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public RefTableController(MastersFactory mFactory, ILogger<RefTableController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<RefTableVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetRefTableRepo.Get();
                var model = mapper.Map<RefTableVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<RefTableVM> Get(int id)
        {
            try
            {
                RefTable data = null;
                data = _mFactory.GetRefTableRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<RefTableVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] RefTableVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<RefTable>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetRefTableRepo.Add(entity);
                _mFactory.GetRefTableRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RefTableVM model)
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
                var entity = mapper.Map<RefTable>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetRefTableRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult Delete(RefTableVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetRefTableRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetRefTableRepo.Delete(entity))
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
