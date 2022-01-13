using CBE.Feature.DiscussionForum.BLL;
using CBE.Feature.DiscussionForum.BLL.DTOs;
using System.Web.Mvc;

namespace CBE.Feature.DiscussionForum.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicsService topicsService;
        public TopicsController(ITopicsService iTS)
        {
            this.topicsService = iTS;
        }
        [HttpPost]
        public void AddTopic(TopicDTO item)
        {
            var result = this.topicsService.AddTopic(item);
            // return View("/Views/DiscussionForum/Topics.cshtml");
        }
    }
}