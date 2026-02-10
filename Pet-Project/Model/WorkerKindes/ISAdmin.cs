using Pet_Project.Model;
using Pet_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Model.WorkerKindes
{
    internal class ISAdmin : Worker
    {
        public ISAdmin() { }
        public ISAdmin(string name, string sername) : base(name, sername) { }

        public override string DoWork()
        {
            List<IS> IMSMain = Responsibility.MainISAdmin[this];
            List<IS> IMSReserve = Responsibility.ReserveISAdmin[this];
            string IMSs = "";
            foreach (var ms in IMSMain)
            { IMSs += ms.Name + "\n"; }
            foreach (var ms in IMSReserve)
            { IMSs += ms.Name + "\n"; }
            return $"Я итак админю это нерабочее #&?!(%:" +
                "{IMSs}";
        }

    }
}
