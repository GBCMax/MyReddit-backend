using Microsoft.EntityFrameworkCore;
using MyReddit.DataAccess.Configurations;
using MyReddit.DataAccess.Entities;

namespace MyReddit.DataAccess
{
    public class MyRedditDbContext : DbContext
    {
        public MyRedditDbContext(DbContextOptions<MyRedditDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
