using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
    public class special_treatment
    {
        

        public special_treatment(string text)
        {
            this.Name = text;
        }
        public special_treatment()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
