using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenderGartenFront.Models
{
    public class Forum
    { public int id { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string date { get; set; }
        public  IList<questionForum> questions { get; set; }

    }
}