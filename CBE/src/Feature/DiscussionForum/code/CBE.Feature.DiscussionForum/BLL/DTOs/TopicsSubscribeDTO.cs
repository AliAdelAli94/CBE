using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.DiscussionForum.BLL.DTOs
{
    public class TopicsSubscribeDTO
    {
        public Guid ID { get; set; }
        public Guid? TopicID { get; set; }

    }
}