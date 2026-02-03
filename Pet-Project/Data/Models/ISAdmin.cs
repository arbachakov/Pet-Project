using Pet_Project.Data.HelpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Models
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


        // TODO Убрать это
        public override double CalculateSalary()
        {
            List<IS> IMSMain = Responsibility.MainISAdmin[this];
            List<IS> IMSReserve = Responsibility.ReserveISAdmin[this];
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
