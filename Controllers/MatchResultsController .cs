using AllocationTeamAPI.Models;
using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace AllocationTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchResultsController : ControllerBase
    {
        private readonly MatchResultService _matchResultService;

        public MatchResultsController(MatchResultService matchResultService)
        {
            _matchResultService = matchResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatchResults()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            var matchResults = await _matchResultService.GetAllMatchResultsAsync(int.Parse(userIdClaim));
            return Ok(matchResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchResultById(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            var matchResult = await _matchResultService.GetMatchResultByIdAndIdUserAsync(id, int.Parse(userIdClaim));
            if (matchResult == null)
            {
                return NotFound();
            }
            return Ok(matchResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchResult([FromBody] dynamic matchResult)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdMatchResult = await _matchResultService.CreateMatchResultAsync(matchResult, int.Parse(userIdClaim));
            /*            return CreatedAtAction(nameof(GetMatchResultById), new { id = createdMatchResult.Id });*/
            return Ok(createdMatchResult.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatchResult(int id, [FromBody] dynamic matchResult)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            if (id != matchResult.Id)
            {
                return BadRequest();
            }
            await _matchResultService.UpdateMatchResultAsync(matchResult,id,int.Parse(userIdClaim));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchResult(int id)
        {
            await _matchResultService.DeleteMatchResultAsync(id);
            return NoContent();
        }
    }
}
