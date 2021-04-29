using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class User
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public int id { get; set; }
        public object photo_url { get; set; }
        public int notif_events { get; set; }
    }
}