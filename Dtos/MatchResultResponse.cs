using System.Text.Json; 
using AllocationTeamAPI.Models;

namespace AllocationTeamAPI.Dtos
{
    public class MatchResultResponse
    {
        public int Id { get; set; }
        public dynamic Result { get; set; }

        public MatchResultResponse(int id, dynamic result)
        {
            Id = id;
            Result = result;
        }

        public static MatchResultResponse FromMatchResult(MatchResult matchResult)
        {
            try
            {
                var matchResultData = JsonSerializer.Deserialize<JsonElement>(matchResult.MatchResultJson);
                return new MatchResultResponse(matchResult.Id, matchResultData);
            }
            catch (JsonException)
            {
                return new MatchResultResponse(matchResult.Id, matchResult.MatchResultJson);
            }


        }
    }

}
