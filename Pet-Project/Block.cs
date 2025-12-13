using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class Block // ТФБ, БИТ
    {
        public string Name { get; set; }

        public Worker Manager { get; set; } // Директор
        
        public List<Department> Departments { get; set; } // Службы


    }
}
