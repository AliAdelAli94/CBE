using CBE.Feature.DiscussionForum.DAL.GenericRepository;
using CBE.Feature.DiscussionForum.DAL.Models;
using CBE.Feature.DiscussionForum.UnitOfWork;
using System;

namespace CBE.Feature.DiscussionForum.DAL.UnitOfWork
{
    public class DiscussionForumUnitOfWork : IDiscussionForumUnitOfWork
    {
        private DiscussionForumDbContext context = new DiscussionForumDbContext();

        private GenericRepository<Topic> topicsRepository;
        private GenericRepository<TopicsComment> topicsCommentsRepository;
        private GenericRepository<TopicsLike> topicsLikesRepository;
        private GenericRepository<TopicsSubscribe> topicsSubscribeRepository;

        public GenericRepository<Topic> TopicsRepository
        {
            get
            {
                if (this.topicsRepository == null)
                {
                    this.topicsRepository = new GenericRepository<Topic>(this.context);
                }
                return this.topicsRepository;
            }
        }
        public GenericRepository<TopicsComment> TopicCommentsRepository
        {
            get
            {
                if (this.topicsCommentsRepository == null)
                {
                    this.topicsCommentsRepository = new GenericRepository<TopicsComment>(this.context);
                }
                return this.topicsCommentsRepository;
            }
        }
        public GenericRepository<TopicsLike> TopicsLikesRepository
        {
            get
            {
                if (this.topicsLikesRepository == null)
                {
                    this.topicsLikesRepository = new GenericRepository<TopicsLike>(this.context);
                }
                return this.topicsLikesRepository;
            }
        }
        public GenericRepository<TopicsSubscribe> TopicsSubscribeRepository
        {
            get
            {
                if (this.topicsSubscribeRepository == null)
                {
                    this.topicsSubscribeRepository = new GenericRepository<TopicsSubscribe>(this.context);
                }
                return this.topicsSubscribeRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            // call audit
            int saveStatus = context.SaveChanges();
            if (saveStatus > 0)
            {
                return true;
            }
            return false;
        }

        private void AddAuditFields()
        {
            //var entities = ChangeTracker.Entries().Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));
            //foreach (var entity in entities)
            //{
            //    if (entity.State == EntityState.Added)
            //    {
            //        ((IAuditable)entity.Entity).CreatedAt = DateTime.Now;

            //        ((IAuditable)entity.Entity).CreatedBy = "Temp User";

            //        ((IAuditable)entity.Entity).ModifiedDate = DateTime.Now;

            //        ((IAuditable)entity.Entity).ModifiedBy = "Temp User";
            //    }
            //    else
            //    {
            //        ((IAuditable)entity.Entity).ModifiedDate = DateTime.Now;

            //        ((IAuditable)entity.Entity).ModifiedBy = "Temp User";
            //    }
            //}
        }
    }
}