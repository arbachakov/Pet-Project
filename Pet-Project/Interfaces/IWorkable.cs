using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Interface
{
    internal interface IWorkable
    {
        public string DoWork();

        public string Name { get; set; }


    }
}
