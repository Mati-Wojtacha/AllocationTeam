using AllocationTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AllocationTeamAPI.Repositories
{
    public class MatchResultRepository : IMatchResultRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchResult>> GetAllMatchResultsAsync()
        {
            return await _context.MatchResults.ToListAsync();
        }

        public async Task<MatchResult> GetMatchResultByIdAsync(int matchResultId)
        {
            return await _context.MatchResults.FindAsync(matchResultId);
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
