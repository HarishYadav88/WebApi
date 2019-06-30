using Microsoft.EntityFrameworkCore;
using WebApi.DataAccessLayer.Configurations;
using WebApi.DataAccessLayer.Entities;

namespace WebApi.DataAccessLayer
{
    public class GroupManagementDbContext : DbContext
    {
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<UserEntity> Users { get; set; }


        public GroupManagementDbContext(DbContextOptions<GroupManagementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
        }
    }
}
