﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KenderGartenFront.Models
{
    public class HomeIndexModel
    {
        public virtual IEnumerable<Post> Posts { get; set; }

    }
}