using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenderGartenFront.Models
{
    public class questionForum
    { public int id { get; set; }
        public string question { get; set; }
        public IList<reponseForum> reponses { get; set; }



    }
}