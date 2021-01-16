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
    public class VendorRegistrationTypeController : ControllerBase
    {
        private readonly ILogger<VendorRegistrationTypeController> Logger;
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        public VendorRegistrationTypeController(MastersFactory mFactory, ILogger<VendorRegistrationTypeController> logger, IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult<VendorRegistrationTypeVM[]> Get()
        {
            try
            {
                var data = _mFactory.GetVendorRegistrationTypeRepo.Get();
                var model = mapper.Map<VendorRegistrationTypeVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<VendorRegistrationTypeVM> Get(int id)
        {
            try
            {
                VendorRegistrationType data = null;
                data = _mFactory.GetVendorRegistrationTypeRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<VendorRegistrationTypeVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] VendorRegistrationTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<VendorRegistrationType>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetVendorRegistrationTypeRepo.Add(entity);
                _mFactory.GetVendorRegistrationTypeRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VendorRegistrationTypeVM model)
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
                var entity = mapper.Map<VendorRegistrationType>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetVendorRegistrationTypeRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult Delete(VendorRegistrationTypeVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetVendorRegistrationTypeRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetVendorRegistrationTypeRepo.Delete(entity))
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
