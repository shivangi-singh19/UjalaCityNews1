using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UjalaCityNews1.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveForHome { get; set; }
    }
}