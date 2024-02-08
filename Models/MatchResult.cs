namespace AllocationTeamAPI.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        public required string MatchResultJson { get; set; } 
        public int UserId { get; set; }
        public required User User { get; set; }

        public MatchResult(string matchResultJson, int userId, User user)
        {
            MatchResultJson = matchResultJson;
            UserId = userId;
            User = user;
        }

        public MatchResult()
        {
        }
    }
}
