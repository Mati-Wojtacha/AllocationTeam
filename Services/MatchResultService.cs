using AllocationTeamAPI.Dtos;
using AllocationTeamAPI.Models;
using AllocationTeamAPI.Repositories;

namespace AllocationTeamAPI.Services
{
    public class MatchResultService
    {
        private readonly IMatchResultRepository _matchResultRepository;
        private readonly UserService _userService;

        public MatchResultService(IMatchResultRepository matchResultRepository, UserService userService)
        {
            _matchResultRepository = matchResultRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<MatchResultResponse>> GetAllMatchResultsAsync(int idUser)
        {
            IEnumerable<MatchResult> matchResults = await _matchResultRepository.GetAllMatchByUserIdResultsAsync(idUser);

            var matchResultResponses = matchResults.Select(matchResult =>
                MatchResultResponse.FromMatchResult(matchResult)).ToList();

            return matchResultResponses;
        }

        private async Task<MatchResult> GetMatchResultByIdAndIdUserAsync(int matchResultId, int idUser)
        {
            return await _matchResultRepository.GetMatchResultByIdAndIdUserAsync(matchResultId, idUser);
        }
        public async Task<MatchResultResponse?> FetchMatchResultForUserAsync(int matchResultId, int idUser)
        {
            MatchResult response = await GetMatchResultByIdAndIdUserAsync(matchResultId, idUser);
            if (response == null)
            {
                return null;
            }
            return MatchResultResponse.FromMatchResult(response);
        }

        public async Task<MatchResult?> CreateMatchResultAsync(dynamic matchResult, int idUser)
        {
            User user = await _userService.GetUserByIdAsync (idUser);
            if(user == null) {
                return null;
            }


            MatchResult match = new MatchResult
            {
                MatchResultJson = matchResult.ToString(),
                UserId = idUser,
                User = user
            };
            MatchResult matchSaved = await _matchResultRepository.CreateMatchResultAsync(match);
            user.MatchResults.Add(matchSaved);
            await _userService.UpdateUser(user);
            return matchSaved;

        }

        public async Task<MatchResult> UpdateMatchResultAsync(dynamic matchResult, int id, int idUser)
        {
            MatchResult match =await GetMatchResultByIdAndIdUserAsync(id, idUser);
            if (match == null)
            {
                return null;
            }
            match.MatchResultJson = matchResult.ToString();
            return await _matchResultRepository.UpdateMatchResultAsync(match);
        }

        public async Task<bool> DeleteMatchResultAsync(int id, int idUser)
        {
            MatchResult match = await GetMatchResultByIdAndIdUserAsync(id, idUser);
            if (match == null)
            {
                return false;
            }
            await _matchResultRepository.DeleteMatchResultAsync(id);
            return true;
        }
    }
}
