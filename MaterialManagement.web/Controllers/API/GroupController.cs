using AutoMapper;
using DAL.Repos.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public ActionResult<ItemGroup> Post([FromBody] ItemGroupVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var entity = mapper.Map<ItemGroup>(model);
                entity.CreatedDate = DateTime.Now;
                mastersFactory.GetGroupRepo.Add(entity);

                mastersFactory.GetGroupRepo.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ItemGroup> Put(int id, [FromBody]  ItemGroupVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != model.Id)
            {
                return BadRequest("Ids did not match");
            }

            if (model == null)
                return NotFound();

            try
            {
                var entity = mapper.Map<ItemGroup>(model);
                entity.ModifiedDate = DateTime.Now;
                 mastersFactory.GetGroupRepo.Update(entity);
                //mastersFactory.GetGroupRepo.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }

        [HttpDelete("{id}")]
        public ActionResult<ItemGroup> Delete(ItemGroupVM model)
        {
            try
            {
                if (model.Id == 0)
                    return BadRequest("Invalid Data.");

                var groupitem = mastersFactory.GetGroupRepo.Get(model.Id);
                if (groupitem == null)
                    return NotFound();

                if (mastersFactory.GetGroupRepo.Delete(groupitem))
                    return Ok();

                return NotFound("Data not updated");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


    }
}
