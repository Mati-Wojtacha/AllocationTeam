namespace AllocationTeamAPI.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        public required string MatchResultJson { get; set; } 
        public int UserId { get; set; }
        public required User User { get; set; } 
    }
}
