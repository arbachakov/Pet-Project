using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Models
{
    internal class NETAdmin : Worker
    {
        public NETAdmin() { }
        public NETAdmin(string name, string sername) : base(name, sername) { }

        public override string DoWork()
        {
            return $"Я просто *что-то на сетевом*";
        }

        // TODO Убрать это
        public override double CalculateSalary()
        {
            return IS.ServerCount * 500;
        }

    }
}
