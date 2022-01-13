using CBE.Feature.DiscussionForum.DAL.GenericRepository;
using CBE.Feature.DiscussionForum.DAL.Models;
using System;

namespace CBE.Feature.DiscussionForum.UnitOfWork
{
    public interface IDiscussionForumUnitOfWork : IDisposable
    {
        GenericRepository<Topic> TopicsRepository { get; }
        GenericRepository<TopicsComment> TopicCommentsRepository { get; }
        GenericRepository<TopicsLike> TopicsLikesRepository { get; }
        GenericRepository<TopicsSubscribe> TopicsSubscribeRepository { get; }
        void Dispose();
        bool SaveChanges();
    }
}