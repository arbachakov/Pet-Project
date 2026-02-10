using Pet_Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pet_Project.Models
{
    internal class Worker 
    {
        public int Id { get; set; }

        //public static int MinAge = 18; // Статические поля
        //public static int MaxAge = 65;

        //public string MainInfo // Автоматическое свойство
        //{ get {return $"{Name} {Sername}" +
        //            $"Age - {Age}" +
        //            $"{JobTitle}";} }

        //public string MainInfo1
        //{
        //    get =>  $"{Name} {Sername}" +
        //            $"Age - {Age}" +
        //            $"{JobTitle}";
            
        //}

        //const string ClassType = "Worker"; // Константа. Инициализируется при компиляции. readonly инициализируется во время выполнения программы

        public string Name { get; set; } = "Unknown";

        public string Sername { get; set; } = "Unknown";

        public Worker() { }
        public Worker(string name)
        {
            Name = name;
        }

        public Worker(string name, string sername)
        {
            Name = name; Sername = sername;  
        }





    }
}
