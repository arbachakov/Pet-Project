using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.HelpModel
{
    internal interface IWorkable
    {
        public string DoWork();

        public double CalculateSalary();
    }
}
