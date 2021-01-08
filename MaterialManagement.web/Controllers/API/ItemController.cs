using AutoMapper;
using DAL.Repos.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;


namespace MaterialManagement.web.Controllers.API
{

    public class ItemController : BaseController
    {
        private readonly MastersFactory _mFactory;
        private readonly IMapper mapper;

        private ILogger<ItemController> Logger { get; }

        public ItemController(MastersFactory mFactory,ILogger<ItemController> logger,IMapper mapper)
        {
            this._mFactory = mFactory;
            Logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get(bool includeGroup=false)
        {
            try
            {
                IEnumerable<Item> data = null;
                if (includeGroup)
                    data = _mFactory.GetItemRepo.GetWithGroupAndUnit();
                else
                    data = _mFactory.GetItemRepo.Get();

                var model=mapper.Map<ItemVM[]>(data);

                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<ItemVM> Get(int id,bool includeGroup = false)
        {
            try
            {
                Item data = null;
                if (includeGroup)
                    data = _mFactory.GetItemRepo.GetWithGroupAndUnit(id);
                else
                    data=_mFactory.GetItemRepo.Get(id);

                if (data == null)
                    return NotFound();

                var model = mapper.Map<ItemVM>(data);

                return Ok(model);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public ActionResult<Item> Post([FromBody] ItemVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<Item>(model);
                entity.CreatedDate = DateTime.Now;
                _mFactory.GetItemRepo.Add(entity);

                _mFactory.GetItemRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Item> Put(int id, [FromBody] ItemVM model)
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
                var entity = mapper.Map<Item>(model);
                entity.ModifiedDate = DateTime.Now;
                _mFactory.GetItemRepo.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(ItemVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var entity = _mFactory.GetItemRepo.Get(model.Id);
                if (entity == null)
                    return NotFound();

                if (_mFactory.GetItemRepo.Delete(entity))
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
