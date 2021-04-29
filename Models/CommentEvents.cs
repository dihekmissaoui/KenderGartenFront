using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CommentEvents
    {
        public DateTime dateCommentEvents { get; set; }
        public int events { get; set; }
        public int users { get; set; }
        public string commentaire { get; set; }
        public CommentEvents()
        {

        }
    }
}