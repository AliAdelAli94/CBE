using CBE.Feature.DiscussionForum.BLL;
using CBE.Feature.DiscussionForum.BLL.DTOs;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult Index()
        {
            var items = this.topicsService.GetAllTopics();
            TempData["topicsItems"] = items;
            return View("/Views/DiscussionForum/Index.cshtml");
        }

        [HttpPost]
        public ActionResult AddTopic(TopicDTO item)
        {
            var result = this.topicsService.AddTopic(item);
            if (result)
            {
                var items = this.topicsService.GetAllTopics();
                return PartialView("/Views/DiscussionForum/PartialViews/_GetAllTopics.cshtml", items);
            }
            else
            {
                return Json(new { status = "error", message = "some thing went wrong" });
            }
        }
    }
}