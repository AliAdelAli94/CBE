using CBE.Feature.DiscussionForum.BLL.DTOs;
using System.Collections.Generic;

namespace CBE.Feature.DiscussionForum.BLL
{
    public interface ITopicsService
    {
        bool AddTopic(TopicDTO item);
        List<TopicDTO> GetAllTopics();
    }
}