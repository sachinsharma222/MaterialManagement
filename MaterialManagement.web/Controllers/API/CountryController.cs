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
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public CountryController(MastersFactory mFactory,ILogger<CountryController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CountryVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetCountryRepo.Get();
                var model = mapper.Map<CountryVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<CountryVM> Get(int id)
        {
            try
            {
                Country data = null;
                data = _mFactory.GetCountryRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<CountryVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult<Company> Post([FromBody] CountryVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<Country>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetCountryRepo.Add(entity);
                _mFactory.GetCountryRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Country> Put(int id, [FromBody] CountryVM model)
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
                var entity = mapper.Map<Country>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetCountryRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<Country> Delete(CountryVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetCountryRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetCountryRepo.Delete(entity))
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
