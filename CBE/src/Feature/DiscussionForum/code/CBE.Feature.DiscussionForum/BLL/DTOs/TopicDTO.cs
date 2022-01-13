using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.DiscussionForum.BLL.DTOs
{
    public class TopicDTO
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public List<TopicsCommentDTO> TopicComments { get; set; }
        public List<TopicsLikeDTO> TopicLikes { get; set; }
    }
}