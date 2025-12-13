using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class ServerAdmin : Worker
    {
        public ServerAdmin() : base() { }

        public List<IMS> IMSList { get; set; }

        public override string DoWork()
        {
            string IMSs = "";
            foreach (var ms in IMSList)
            { IMSs += ms.Name + "\n"; }
            return $"Я итак админю это нерабочее #&?!(%:" +
                "{IMSs}";
        }

        public override double CalculateSalary() // Со словом override происходит переинициализация метода
        {
            double salary = 0;
            foreach (var ms in IMSList)
            {
                salary += ms.SalaryCost * 1.1 + 1000;
            }
            return salary;
        }

        public new string GetInfo() // Со словом new происходит скрытие метода 
        {
            string text = base.GetInfo();
            text += "\nАдминистрирует:";
            foreach (var ms in IMSList) { text += ms.Name + "\n"; }
            return text;
        }
    }
}
