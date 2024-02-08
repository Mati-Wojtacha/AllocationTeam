namespace AllocationTeamAPI.Interfaces
{
public interface ITokenManager
    {
        void DisableToken(string token);
        bool IsTokenActive(string token);
    }
}
