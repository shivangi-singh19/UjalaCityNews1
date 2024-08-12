using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UjalaCityNews1.Models
{
    public class AddUser
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}