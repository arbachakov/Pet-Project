using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Models.OfficeStructure
{
    internal class Department // Службы
    {
        public Department() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public Manager Manager { get; set; } // Начальник службы
        public List<Worker> Workers { get; set; }
    }
}
