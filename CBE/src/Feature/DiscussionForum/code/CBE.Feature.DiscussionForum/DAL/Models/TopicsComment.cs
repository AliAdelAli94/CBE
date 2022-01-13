using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBE.Feature.DiscussionForum.DAL.Models
{
    public class TopicsComment : IAuditable
    {
        [Key]
        public Guid ID { get; set; }
        public Guid? TopicID { get; set; }
        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }
        public string Content { get; set; }
        public Guid? TopicCommentID { get; set; }
        [ForeignKey("TopicCommentID")]
        public virtual TopicsComment ParentComment { get; set; }
        public virtual ICollection<TopicsComment> Replies { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
