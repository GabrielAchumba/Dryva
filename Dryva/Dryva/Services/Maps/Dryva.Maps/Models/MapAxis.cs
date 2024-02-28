﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Models
{
    public class MapAxis : EntityBase
    {
        public string Code { get; set; }
        public string ParentCode { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Zoom { get; set; }
    }
}
