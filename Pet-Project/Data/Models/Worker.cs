using Pet_Project.Data.HelpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pet_Project.Data.Models
{
    internal abstract class Worker : IWorkable
    {


        public int ID { get; set; }

        public static int MinAge = 18; // Статические поля
        public static int MaxAge = 65;

        public string MainInfo // Автоматическое свойство
        { get {return $"{Name} {Sername}" +
                    $"Age - {Age}" +
                    $"{JobTitle}";} }

        public string MainInfo1
        {
            get =>  $"{Name} {Sername}" +
                    $"Age - {Age}" +
                    $"{JobTitle}";
            
        }

        const string ClassType = "Worker"; // Константа. Инициализируется при компиляции. readonly инициализируется во время выполнения программы

        public string Name { get; set; } = "Unknown";

        public string Sername { get; set; } = "Unknown";

        public Status Status { get; set; } = Status.Working;

        public JobTitle JobTitle { get; set; } = JobTitle.LeadingSpecialist;

        public double Salary { get; set; } 

        public int Age { get; set; }

        public Worker() { }

        public Worker(string name, string sername)
        {
            Name = name; Sername = sername;  
        }

        public Worker(string name, string sername, Status status, JobTitle jobTitle)
        {
            Name = name; Sername = sername;  
            Status = status; JobTitle = jobTitle;
        }

        public abstract string DoWork();

        public abstract double CalculateSalary();

        public string GetInfo()
        {
            return MainInfo;
        }



    }
}
