using AllocationTeamAPI.Models;

namespace AllocationTeamAPI.Repositories
{
    public interface IMatchResultRepository
    {
        Task<IEnumerable<MatchResult>> GetAllMatchResultsAsync();
        Task<MatchResult> GetMatchResultByIdAsync(int matchResultId);
        Task<MatchResult> CreateMatchResultAsync(MatchResult matchResult);
        Task<MatchResult> UpdateMatchResultAsync(MatchResult matchResult);
        Task DeleteMatchResultAsync(int matchResultId);
    }
}
