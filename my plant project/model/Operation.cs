﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
    public class Operation
    {
        public Operation() { }
        public Operation(string name) { this.name = name; }
        public int Id { get; set; } 
        public string name { get; set; }
    }
}
