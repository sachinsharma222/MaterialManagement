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
    public class GroupController : BaseController
    {
        private readonly ILogger<GroupController> logger;
        private readonly MastersFactory mastersFactory;
        private readonly IMapper mapper;

        public GroupController(ILogger<GroupController> logger, MastersFactory mastersFactory, IMapper mapper)
        {
            this.logger = logger;
            this.mastersFactory = mastersFactory;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ItemGroupVM[]> Get()
        {
            try
            {
                var data = mastersFactory.GetGroupRepo.Get();
                var model = mapper.Map<ItemGroupVM[]>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<ItemGroup> Get(int id)
        {
            try
            {
                ItemGroup data = null;
                data = mastersFactory.GetGroupRepo.Get(id);
                if (data == null)
                    return NotFound();

                var model = mapper.Map<ItemGroupVM>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


    }
}
