using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
   public class Details
    {
        public int Id { get; set; }
        public Operation operation { get; set; }
        public string Disease { get; set; }
        public DateTime Period { get; set; }
    }
}
