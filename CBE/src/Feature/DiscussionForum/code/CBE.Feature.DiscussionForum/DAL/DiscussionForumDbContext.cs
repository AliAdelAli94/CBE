using CBE.Feature.DiscussionForum.DAL.Models;
using System;
using System.Configuration;
using System.Data.Entity;

namespace CBE.Feature.DiscussionForum.DAL
{
    public class DiscussionForumDbContext : DbContext
    {
        public DiscussionForumDbContext()
        {
            Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["CBE"].ConnectionString;
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicsComment> TopicsComments { get; set; }
        public DbSet<TopicsLike> TopicsLikes { get; set; }
        public DbSet<TopicsSubscribe> TopicsSubscribes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
              .Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }

    }
}
