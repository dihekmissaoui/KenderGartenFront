using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ReactEvents
    {
        public int id_react { get; set; }
        public string react { get; set; }
        public User users { get; set; }
        public Events events { get; set; }

        public ReactEvents()
        {

        }
    }
}