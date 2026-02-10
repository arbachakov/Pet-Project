using Pet_Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Model.WorkerKindes
{
    internal class ServerAdmin
    {
        //public ServerAdmin(string name, string sername) : base(name, sername) { }

        public List<IS> IMSList { get; set; }

        public string DoWork()
        {
            string IMSs = "";
            foreach (var ms in IMSList)
            { IMSs += ms.Name + "\n"; }
            return $"Я итак админю это нерабочее #&?!(%:" +
                "{IMSs}";
        }


        //public new string GetInfo() // Со словом new происходит скрытие метода 
        //{
        //    string text = base.GetInfo();
        //    text += "\nАдминистрирует:";
        //    foreach (var ms in IMSList) { text += ms.Name + "\n"; }
        //    return text;
        //}
    }
}
