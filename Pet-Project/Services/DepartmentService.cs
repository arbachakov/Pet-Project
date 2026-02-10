using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Services
{
    internal class DepartmentService : IServicable<Department>
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly IdGeneratorService _idGeneratorService;

        public DepartmentService(DepartmentRepository departmentRepository,
            IdGeneratorService idGeneratorService)
        {
            _departmentRepository = departmentRepository;
            _idGeneratorService = idGeneratorService;
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public string ViewAll()
        {
            string departmentsInfo = "";
            List<Department> departments = GetAll();
            if (departments.Count == 0)
            { return "Отделов нет("; }
            for (int i = 0; i < departments.Count; i++)
            {
                departmentsInfo += $"Название: {departments[i].Name} Id: {departments[i].Id}\n";
            }
            return departmentsInfo;
        }

        public bool ChangeNameById(int id, string newName)
        {
            if (_departmentRepository.ChangeNameById(id, newName))
            { return true; }
            return false;

        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public Department Create(string name)
        {
            Department department = new Department(name);
            department.Id = _idGeneratorService.GenerateID();
            _departmentRepository.Add(department);
            return department;
        }

        public bool DeleteById(int id)
        {
            if (_departmentRepository.DeleteById(id))
            { return true; }
            return false;
        }
    }
}
