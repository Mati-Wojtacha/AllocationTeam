namespace AllocationTeamAPI.Dtos
{
    public class UserLoginResponse
    {
        public string Token { get; } 
        public int Id { get; }
        public string Username { get; }
        public string Email { get; }

        public UserLoginResponse(int id, string username, string email, string token)
        {
            Id = id;
            Username = username;
            Email = email;
            Token = token;
        }
    }
}
