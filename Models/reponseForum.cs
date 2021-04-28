using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenderGartenFront.Models
{
    public class reponseForum
    { public int id { get; set; }
        public string reponse {get;set;}
        public  questionForum question { get; set; }


    }
}