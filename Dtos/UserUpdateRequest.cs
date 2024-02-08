using System.ComponentModel.DataAnnotations;

namespace AllocationTeamAPI.Dtos
{
    public class UserUpdateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
