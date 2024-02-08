using AllocationTeamAPI.Models;
using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllocationTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var matchResults = await _matchResultService.GetAllMatchResultsAsync();
            return Ok(matchResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchResultById(int id)
        {
            var matchResult = await _matchResultService.GetMatchResultByIdAsync(id);
            if (matchResult == null)
            {
                return NotFound();
            }
            return Ok(matchResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchResult([FromBody] MatchResult matchResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdMatchResult = await _matchResultService.CreateMatchResultAsync(matchResult);
            return CreatedAtAction(nameof(GetMatchResultById), new { id = createdMatchResult.Id }, createdMatchResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatchResult(int id, [FromBody] MatchResult matchResult)
        {
            if (id != matchResult.Id)
            {
                return BadRequest();
            }
            await _matchResultService.UpdateMatchResultAsync(matchResult);
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
