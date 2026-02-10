using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Services
{
    internal class IdGeneratorService
    {

        static Random _rnd = new Random();
        private List<int> _staffIds = new List<int>();

        public int GenerateID()
        {
            int id;
            // TODO Пересмотреть логику...
            do
            {
                id = _rnd.Next(0, 100000);
                _staffIds.Add(id);
            } while (_staffIds.Contains(id));
            return id;
        }
    }
}
