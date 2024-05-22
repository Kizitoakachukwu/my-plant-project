using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
    public class Operationlist
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public plants plants { get; set; }
        public Operation Operation { get; set; }
        public Harmful_obj harmful_Obj { get; set; }
        
    }
}
