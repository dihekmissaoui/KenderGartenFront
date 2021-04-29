using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Main
    {
        public User users { get; set; }
        public Events events { get; set; }
        public ReactEvents React { get; set; }
        public CommentEvents commentEvents { get; set; }
    }
}