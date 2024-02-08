namespace AllocationTeamAPI.Models
{
    using AllocationTeamAPI.Dtos;
    using System;

    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }
        public List<MatchResult> MatchResults { get; set; } = new List<MatchResult>();

    }

}
