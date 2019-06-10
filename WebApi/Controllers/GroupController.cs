using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.BusinessLayer.Interfaces;
using WebApi.BusinessLayer.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupsService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupservice, ILogger<GroupController> logger)
        {
            _groupsService = groupservice;
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