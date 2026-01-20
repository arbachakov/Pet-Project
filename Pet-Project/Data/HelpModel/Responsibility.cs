using Pet_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.HelpModel
{
    internal static class Responsibility
    {
        public static Dictionary<ISAdmin, List<IS>> MainISAdmin; // Не сам додумался. Снова кринж(
        public static Dictionary<ISAdmin, List<IS>> ReserveISAdmin;
    }
}
