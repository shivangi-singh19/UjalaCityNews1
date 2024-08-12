using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UjalaCityNews1.Models
{
    public class PostCatWise
    {
        public string CategoryItem { get; set; }
        public List<NewsPosts> Posts { get; set; }
    }
    public class NewsPosts
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string HindiTitle { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public string DateString { get; set; } = "";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public HttpPostedFileBase Image { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Slug { get; set; }
    }
}