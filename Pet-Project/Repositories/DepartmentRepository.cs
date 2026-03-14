using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Pattern;

namespace Pet_Project.Repositories
{
    internal class DepartmentRepository : IRepository<Department>
    {

        private List<Department> _departments = new List<Department>();

        public Result<List<Department>> GetAll() 
        {
            return Result<List<Department>>.Ok(_departments, "Список получен из репозитория");
        }

        public Result<Department> Add(Department department) 
        {
            _departments.Add(department);
            return Result<Department>.Ok(department, $"Служба {department.Id} добавлен в репозиторий");
        }


        public Result<Department> GetById(int id) 
        {
            for (int i = 0; i < _departments.Count; i++)
            {
                if (_departments[i].Id == id)
                    return Result<Department>.Ok(_departments[i], $"Рабочий {_departments[i].Id} найден");
            }
            return Result<Department>.Fail("Рабочий не найден в репозитории");
        }


        public Result<Department> ChangeNameById(int id, string newName) 
        {
            Result<Department> result = GetById(id);

            if (result.Success)
            {
                Department department = result.Data;
                string oldName = department.Name;
                department.Name = newName;
                return Result<Department>.Ok(department, $"У работника с id {department.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<Department>.Fail(result.Message);
            }
        }


        public Result<Department> DeleteById(int id) // bool
        {
            Result<Department> result = GetById(id);

            if (result.Success)
            {
                Department department = result.Data;
                _departments.Remove(department);
                return Result<Department>.Ok(department, $"Рабочий {department.Id} удален"); ;
            }
            else
            {
                return Result<Department>.Fail(result.Message);
            }
        }
    }
}
