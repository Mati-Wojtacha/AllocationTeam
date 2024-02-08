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
        public ActionResult<List<Tuple<int, List<int>, List<int>>>> GenerateCombinations(int nInput)
        {
            var combinations = _combinationService.GenerateCombinations(nInput);
            return Ok(combinations);
        }

        [HttpGet("teams/tableNames")]
        public ActionResult<List<Tuple<int, List<string>, List<string>>>> CombinationsToString([FromQuery] string[] tableNames)
        {
            var stringCombinations = _combinationService.CombinationsToString(tableNames);
            return Ok(stringCombinations);
        }
    }

}
