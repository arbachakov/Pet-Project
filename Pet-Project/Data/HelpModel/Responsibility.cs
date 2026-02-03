using Pet_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.HelpModel
{

    // TODO добавить менеджемент
    internal static class Responsibility
    {
        public static Dictionary<ISAdmin, List<IS>> MainISAdmin;
        public static Dictionary<ISAdmin, List<IS>> ReserveISAdmin;
    }
}
