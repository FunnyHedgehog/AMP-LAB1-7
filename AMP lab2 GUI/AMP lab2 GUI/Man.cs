using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMP_lab2_GUI
{
    class Man
    {
        public string Name { get; set; }
        public Man() { }
        public void Work() { }
        public virtual void Relax(ref string place, out int happiness, int day = 5) {
            happiness = 10;
        }
    }
}
