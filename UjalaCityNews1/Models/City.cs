﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UjalaCityNews1.Models
{
    public class City
    {
        public int c_id { get; set; }
        public int s_id { get; set; }
        public string city_hindi { get; set; }
        public string city_eng { get; set; }
        public string state_eng { get; set; }
        public string state_hindi { get; set; }
    }
}