using AllocationTeamAPI.Models;

namespace AllocationTeamAPI.Repositories
{
    public interface IMatchResultRepository
    {
        Task<IEnumerable<MatchResult>> GetAllMatchByUserIdResultsAsync(int idUser);
        Task<MatchResult> GetMatchResultByIdAndIdUserAsync(int matchResultId, int idUser);
        Task<MatchResult> CreateMatchResultAsync(MatchResult matchResult);
        Task<MatchResult> UpdateMatchResultAsync(MatchResult matchResult);
        Task DeleteMatchResultAsync(int matchResultId);
    }
}
