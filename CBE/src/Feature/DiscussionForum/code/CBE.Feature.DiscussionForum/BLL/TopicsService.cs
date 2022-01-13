using AutoMapper;
using CBE.Feature.DiscussionForum.BLL.DTOs;
using CBE.Feature.DiscussionForum.DAL.Models;
using CBE.Feature.DiscussionForum.Mappers;
using CBE.Feature.DiscussionForum.UnitOfWork;
using System;

namespace CBE.Feature.DiscussionForum.BLL
{
    public class TopicsService : ITopicsService
    {
        private readonly IDiscussionForumUnitOfWork discussionForumUnitOfWork;
        private IMapper Mapper { get; set; }

        public TopicsService(IDiscussionForumUnitOfWork dFUOW)
        {
            discussionForumUnitOfWork = dFUOW;
            var config = new MapperConfiguration(x => x.AddProfile(new DiscussionForumMappingProfile()));
            Mapper = config.CreateMapper();
        }

        public bool AddTopic(TopicDTO item)
        {
            try
            {
                var data = Mapper.Map<Topic>(item);
                data.ID = Guid.NewGuid();
                data.CreatedAt = DateTime.Now;
                data.CreatedBy = "User Temp";
                this.discussionForumUnitOfWork.TopicsRepository.Insert(data);
                this.discussionForumUnitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                // write log code here
            }
        }
    }
}