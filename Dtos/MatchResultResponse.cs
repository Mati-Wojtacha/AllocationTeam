using Newtonsoft.Json.Linq;
using AllocationTeamAPI.Models;

namespace AllocationTeamAPI.Dtos
{
    public class MatchResultResponse
    {
        public int Id { get; set; }
        public string Result { get; set; }

        public MatchResultResponse(int id, string result)
        {
            Id = id;
            Result = result;
        }

        public static MatchResultResponse FromMatchResult(MatchResult matchResult)
        {
            return new MatchResultResponse(matchResult.Id, matchResult.MatchResultJson);
        }
    }

}
