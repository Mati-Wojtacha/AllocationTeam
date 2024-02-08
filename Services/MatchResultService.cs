using AllocationTeamAPI.Models;
using AllocationTeamAPI.Repositories;

namespace AllocationTeamAPI.Services
{
    public class MatchResultService
    {
        private readonly IMatchResultRepository _matchResultRepository;

        public MatchResultService(IMatchResultRepository matchResultRepository)
        {
            _matchResultRepository = matchResultRepository;
        }

        public async Task<IEnumerable<MatchResult>> GetAllMatchResultsAsync()
        {
            return await _matchResultRepository.GetAllMatchResultsAsync();
        }

        public async Task<MatchResult> GetMatchResultByIdAsync(int matchResultId)
        {
            return await _matchResultRepository.GetMatchResultByIdAsync(matchResultId);
        }

        public async Task<MatchResult> CreateMatchResultAsync(MatchResult matchResult)
        {
            return await _matchResultRepository.CreateMatchResultAsync(matchResult);
        }

        public async Task<MatchResult> UpdateMatchResultAsync(MatchResult matchResult)
        {
            return await _matchResultRepository.UpdateMatchResultAsync(matchResult);
        }

        public async Task DeleteMatchResultAsync(int matchResultId)
        {
            await _matchResultRepository.DeleteMatchResultAsync(matchResultId);
        }
    }
}
