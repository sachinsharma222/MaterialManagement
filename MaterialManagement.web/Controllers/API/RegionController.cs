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
    public class RegionController : ControllerBase
    {

        private readonly ILogger<RegionController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public RegionController(MastersFactory mFactory, ILogger<RegionController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<RegionVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetRegionRepo.Get();
                var model = mapper.Map<RegionVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<RegionVM> Get(int id)
        {
            try
            {
                Region data = null;
                data = _mFactory.GetRegionRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<RegionVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult<Region> Post([FromBody] RegionVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<Region>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetRegionRepo.Add(entity);
                _mFactory.GetRegionRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Region> Put(int id, [FromBody] RegionVM model)
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
                var entity = mapper.Map<Region>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetRegionRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<Region> Delete(RegionVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetRegionRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetRegionRepo.Delete(entity))
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
