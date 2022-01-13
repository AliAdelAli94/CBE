using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBE.Feature.DiscussionForum.DAL.Models
{
    public class Topic : IAuditable
    {
        [Key]
        public Guid ID { get; set; }
        public string Content { get; set; }
        public virtual ICollection<TopicsComment> TopicComments { get; set; }
        public virtual ICollection<TopicsLike> TopicLikes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
