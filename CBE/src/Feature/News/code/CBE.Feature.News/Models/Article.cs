using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.News.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
    }
}