using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal static class Responsibility
    {
        public static Dictionary<IMSAdmin, List<IMS>> MainAdminIMS; // Не сам додумался. Снова кринж(
        public static Dictionary<IMSAdmin, List<IMS>> ReserveAdminIMS;
    }
}
