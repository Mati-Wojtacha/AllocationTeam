using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace AllocationTeamAPI.Controllers
{
    public class CombinationsController : ControllerBase
    {
        private readonly CombinationService _combinationService;

        public CombinationsController()
        {
            _combinationService = new CombinationService();
        }

        [HttpGet("teams/{nInput}")]
        public ActionResult<Object> GenerateCombinations(int nInput)
        {
            var combinations = _combinationService.GenerateCombinations(nInput);
            return Ok(combinations);
        }

        [HttpGet("teams/tableNames")]
        public ActionResult<Object> CombinationsToString([FromQuery] string[] tableNames)
        {
            var stringCombinations = _combinationService.CombinationsToString(tableNames);
            return Ok(stringCombinations);
        }
    }

}
