using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Events
    {
        public int id_events { get; set; }
        public byte[] affiche_events { get; set; }
        public int participates { get; set; }
        public string name_events { get; set; }
        public string date_events { get; set; }
        public int not_interested { get; set; }
        public int interested { get; set; }
        public string description_events { get; set; }
      
        public List<ReactEvents> reactEvents = new List<ReactEvents>(); 
        public Events()
        {

        }

    }

}