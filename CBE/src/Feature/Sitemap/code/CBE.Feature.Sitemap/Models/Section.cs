using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Sitemap.Models
{
    public class Section
    {
        public Section()
        {
            ChildrenPages = new List<Page>();
            ChildrenSections = new List<Section>();
        }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<Page> ChildrenPages { get; set; }
        public List<Section> ChildrenSections { get; set; }
    }
}