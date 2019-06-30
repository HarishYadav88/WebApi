using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Application.Queries;
using WebApi.BusinessLayer.Interfaces;
using WebApi.BusinessLayer.Models;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupsService;
        private readonly IGroupQueries _groupQueries;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupservice, IGroupQueries groupqueries, ILogger<GroupController> logger)
        {
            _groupsService = groupservice;
            _groupQueries = groupqueries;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups(CancellationToken cancellationToken)
        {

            try
            {
                var groups = await _groupsService.GetAllAsync(cancellationToken);

                if (groups == null)
                {
                    return NotFound("No data found !");
                }

                return Ok(groups);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error Occurred");
                return BadRequest();
            }
            
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetGroup(int Id, CancellationToken cancellationToken)
        {
            var groups = await _groupsService.GetByIdAsync(Id, cancellationToken);

            if (groups == null)
            {
                return NotFound("No data found !");
            }

            return Ok(groups);
        }

        //[Route("{Id:int}")]
        //[HttpGet]
        //[ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult> GetGroupAsync(int Id)
        //{
        //    try
        //    {
        //        var group = await _groupQueries.GetGroupAsync(Id);
        //        return Ok(group);
        //    }
        //    catch(Exception e)
        //    {
        //        _logger.LogError(e, "Error Occurred");
        //        return NotFound();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] Group group, CancellationToken cancellationToken)
        {
            var addedGroup = await _groupsService.AddAsync(group, cancellationToken);

            if (addedGroup == null)
            {
                return NotFound("No data found !");
            }

            return Ok(addedGroup);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup(Group group, CancellationToken cancellationToken)
        {
            var updatedGroup = await _groupsService.UpdateAsync(group, cancellationToken);

            if (updatedGroup == null)
            {
                return NotFound("No data found !");
            }

            return Ok(updatedGroup);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(Group group, CancellationToken cancellationToken)
        {
            var updatedGroup = await _groupsService.RemoveAsync(group, cancellationToken);

            if (updatedGroup == null)
            {
                return NotFound("No data found !");
            }

            return Ok(updatedGroup);
        }

    }
}