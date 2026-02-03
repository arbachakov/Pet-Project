using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Models
{
    internal class IS
    {
        public string Name { get; set; }

        public static int ServerCount { get; set; } = 4;


        // TODO ПОдумать, что с этим делать
        public int SalaryCost { get; set; } 
    }
}
