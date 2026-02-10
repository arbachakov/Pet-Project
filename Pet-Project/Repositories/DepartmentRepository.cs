using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Models.OfficeStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class DepartmentRepository : IRepository<Department>
    {

        private List<Department> _departmants = new List<Department>();

        public List<Department> GetAll()
        {
            return _departmants;
        }

        public bool Add(Department department)
        {
            _departmants.Add(department);
            return true;
        }


        public Department GetById(int id)
        {
            for (int i = 0; i < _departmants.Count; i++)
            {
                if (_departmants[i].Id == id)
                    return _departmants[i];
            }
            return null;
        }


        public bool ChangeNameById(int id, string newName)
        {
            Department department = GetById(id);
            if (department != null)
            {
                department.Name = newName;
                return true;
            }
            return false;

        }


        public bool DeleteById(int id)
        {
            Department department = GetById(id);
            if (department != null)
            {
                _departmants.Remove(department);
                return true;
            }
            return false;

        }
    }
}
