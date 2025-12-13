using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class Department // Службы
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Worker Manager { get; set; } // Начальник службы
        public List<Worker> Workers { get; set; }
    }
}
