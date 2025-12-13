using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class IMSAdmin : Worker
    {

       

        public IMSAdmin()
        {
        }

        public override string DoWork()
        {
            List<IMS> IMSMain = Responsibility.MainAdminIMS[this];
            List<IMS> IMSReserve = Responsibility.ReserveAdminIMS[this];
            string IMSs = "";
            foreach (var ms in IMSMain)
            { IMSs += ms.Name + "\n"; }
            foreach (var ms in IMSReserve)
            { IMSs += ms.Name + "\n"; }
            return $"Я итак админю это нерабочее #&?!(%:" +
                "{IMSs}";
        }



        public override double CalculateSalary()
        {
            List<IMS> IMSMain = Responsibility.MainAdminIMS[this];
            List<IMS> IMSReserve = Responsibility.ReserveAdminIMS[this];
            double salary = 0;
            foreach (var ms in IMSMain)
            {
                salary += ms.SalaryCost * 1.2;
            }
            foreach (var ms in IMSReserve)
            {
                salary += ms.SalaryCost * 1.1;
            }
            return salary;
        }

        public void InsreaseSalary()
        { Salary += 1000; }

        public void InsreaseSalary(double dopSalary) // Перегрузка
        { Salary += dopSalary; }

        public void Deconstruct(out string name, out string sername) // Деконструктор
        {
            name = this.Name;
            sername = this.Sername;
        }
    }
}
