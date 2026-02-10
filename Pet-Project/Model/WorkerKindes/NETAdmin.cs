using Pet_Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Model.WorkerKindes
{
    internal class NETAdmin : Worker
    {
        public NETAdmin() { }
        public NETAdmin(string name, string sername) : base(name, sername) { }

        public override string DoWork()
        {
            return $"Я сетевик!";
        }

    }
}
