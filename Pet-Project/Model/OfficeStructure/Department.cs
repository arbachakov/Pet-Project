using Pet_Project.Model.WorkerKindes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Models.OfficeStructure
{
    internal class Department // Службы
    {
        public Department() { }

        public Department(string name) 
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
