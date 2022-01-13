using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.DiscussionForum.BLL.DTOs
{
    public class TopicsCommentDTO
    {
        public Guid ID { get; set; }
        public Guid? TopicID { get; set; }
        public string Content { get; set; }
        public Guid? TopicCommentID { get; set; }
        public List<TopicsCommentDTO> Replies { get; set; }
    }
}