using AllocationTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace AllocationTeamAPI
{

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  {}
        public DbSet<User> Users { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
    }

}
