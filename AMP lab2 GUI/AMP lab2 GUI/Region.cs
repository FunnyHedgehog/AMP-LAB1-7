using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMP_lab2_GUI
{
    class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } // название регіона
        public ICollection<Tour> Tours { get; set; }
    }
}
