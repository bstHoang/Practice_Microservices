using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserService.Models
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
