﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public string CreatorId { get; set; }
    }
}