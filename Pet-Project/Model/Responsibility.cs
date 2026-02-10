using Pet_Project.Model.WorkerKindes;
using Pet_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Model
{

    // TODO добавить менеджемент, блоки, службы
    internal static class Responsibility
    {
        public static Dictionary<ISAdmin, List<IS>> MainISAdmin;
        public static Dictionary<ISAdmin, List<IS>> ReserveISAdmin;


    }
}
