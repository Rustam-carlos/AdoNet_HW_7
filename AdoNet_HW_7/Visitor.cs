using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_7
{
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int DocNumber { get; set; }
        public DateTime ComingTime { get; set; }
        public string Intention { get; set; }
        public DateTime GoneTime { get; set; }

        public Visitor()
        {
            Name = "";
            SecondName = "";
            DocNumber = 0;
            ComingTime = DateTime.Now;
            Intention = "";
            GoneTime = DateTime.Now;
        }
    }
}
