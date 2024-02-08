using AllocationTeamAPI.Interfaces;

namespace AllocationTeamAPI.Configuration
{
    public class TokenManager : ITokenManager
    {
        private readonly HashSet<string> revokedTokens = new HashSet<string>();

        public void DisableToken(string token)
        {
            if (!revokedTokens.Contains(token))
            {
                revokedTokens.Add(token);
            }
        }

        public bool IsTokenActive(string token)
        {
            return !revokedTokens.Contains(token);
        }
    }
}
