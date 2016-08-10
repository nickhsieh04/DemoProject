﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.Models
{
    public class FacebookLoginModel
    {
        public string uid { get; set; }
        public string accessToken { get; set; }
    }

    public class Picture
    {
        public PicureData data { get; set; }
    }
    public class PicureData
    {
        public string url { get; set; }
        public bool is_silhouette { get; set; }
    }

    public class FacebookUserModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public string link { get; set; }
        //public string username { get; set; }
        public string name { get; set; }
        public int timezone { get; set; }
        public FacebookLocation location { get; set; }
        public Picture picture { get; set; }
        public age age_range { get; set; }
    }
    public class FacebookLocation
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class age
    {
        public Int32? min { get; set; }
        public Int32? max { get; set; }
    }
}