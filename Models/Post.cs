using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenderGartenFront.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<object> Comments { get; set; }
    }
}