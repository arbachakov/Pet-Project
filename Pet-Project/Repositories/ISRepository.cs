using Pet_Project.Models;
using Pet_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class ISRepository : IRepository<IS>
    {
        private List<IS> _iss = new List<IS>();

        public List<IS> GetAll()
        { return _iss; }

        public bool Add(IS IS)
        {
            _iss.Add(IS);
            return true;
        }


        public IS GetById(int id)
        {
            for (int i = 0; i < _iss.Count; i++)
            {
                if (_iss[i].Id == id)
                    return _iss[i];
            }
            return null;
        }


        public bool ChangeNameById(int id, string newName)
        {
            IS IS = GetById(id);
            if (IS != null)
            {
                IS.Name = newName;
                return true;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            IS IS = GetById(id);
            if (IS != null)
            {
                _iss.Remove(IS);
                return true;
            }
            return false;

        }
    }
}
