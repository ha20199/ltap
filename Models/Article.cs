using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ltap.Models
{
    public class Article
    {
        public string ArticleID { get; set; }
        public string Author { get; set; }
        [AllowHtml]
        public string Articlecontent { get; set; }
    }
}