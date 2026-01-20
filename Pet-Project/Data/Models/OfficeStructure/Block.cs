using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Models.OfficeStructure
{
    internal class Block // ТФБ, БИТ
    {
        public Block() { }

        public string Name { get; set; }

        public Manager Manager { get; set; } // Директор
        
        public List<Department> Departments { get; set; } // Службы


    }
}
