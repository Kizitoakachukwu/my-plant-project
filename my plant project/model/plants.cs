using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
    public class plants
    {
        public int Id { get; set; }
        public string name {get; set;}
        public string name_plan {get; set;}
        public plants(string name, string name_plan)
        {
            this.name = name;
            this.name_plan = name_plan;
        }
        public plants() { }
    }
}
