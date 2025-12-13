using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class IMS
    {
        public string Name { get; set; }

        public static int ServerCount { get; set; } = 4;

        public int SalaryCost { get; set; } // Сколько платят за админство. Если бы в жизни так работало...(((
    }
}
