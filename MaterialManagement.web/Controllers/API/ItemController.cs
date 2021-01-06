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
        private readonly MastersFactory mFactory;
        private readonly IMapper mapper;

        private ILogger<ItemController> Logger { get; }

        public ItemController(MastersFactory mFactory,ILogger<ItemController> logger,IMapper mapper)
        {
            this.mFactory = mFactory;
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
                    data = mFactory.GetItemRepo.GetWithGroupAndUnit();
                else
                    data = mFactory.GetItemRepo.Get();

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
                    data = mFactory.GetItemRepo.GetWithGroupAndUnit(id);
                else
                    data=mFactory.GetItemRepo.Get(id);

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
    }
}
