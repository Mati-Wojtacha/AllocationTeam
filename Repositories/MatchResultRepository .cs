using AllocationTeamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AllocationTeamAPI.Repositories
{
    public class MatchResultRepository : IMatchResultRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchResult>> GetAllMatchByUserIdResultsAsync(int userId)
        {
            return await _context.MatchResults.Where(mr => mr.UserId == userId).ToListAsync();
        }

        public async Task<MatchResult> GetMatchResultByIdAndIdUserAsync(int matchResultId, int idUser)
        {
            return await _context.MatchResults.FirstOrDefaultAsync(mr => mr.Id == matchResultId && mr.UserId == idUser);
        }

        public async Task<MatchResult> CreateMatchResultAsync(MatchResult matchResult)
        {
            _context.MatchResults.Add(matchResult);
            await _context.SaveChangesAsync();
            return matchResult;
        }

        public async Task<MatchResult> UpdateMatchResultAsync(MatchResult matchResult)
        {
            _context.Entry(matchResult).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return matchResult;
        }

        public async Task DeleteMatchResultAsync(int matchResultId)
        {
            var matchResult = await _context.MatchResults.FindAsync(matchResultId);
            if (matchResult != null)
            {
                _context.MatchResults.Remove(matchResult);
                await _context.SaveChangesAsync();
            }
        }
    }
}
