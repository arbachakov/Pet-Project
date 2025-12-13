using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class NETAdmin : Worker
    {
        public override string DoWork()
        {
            return $"Я просто *что-то на сетевом*";
        }

        public override double CalculateSalary()
        {
            return IMS.ServerCount * 500;
        }

    }
}
