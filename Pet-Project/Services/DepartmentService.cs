using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Pattern;
using Pet_Project.Repositories;

namespace Pet_Project.Services
{
    internal class DepartmentService : IServicable<Department>
    {
        private readonly DepartmentRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public DepartmentService(DepartmentRepository departmentRepository,
            IdGeneratorService idGeneratorService)
        {
            _repository = departmentRepository;
            _idGeneratorService = idGeneratorService;
        }

        #region Repository
        public Result<List<Department>> GetAll()
        {
            Result<List<Department>> resultDepartment = _repository.GetAll();

            if (resultDepartment.Success)
            {
                return Result<List<Department>>.Ok(resultDepartment.Data, resultDepartment.Message);
            }
            else
            {
                return Result<List<Department>>.Fail(resultDepartment.Message);
            }
        }

        public Result<string> GetInfo()
        {
            Result<List<Department>> result = _repository.GetAll();

            if (result.Success)
            {
                List<Department> departments = result.Data;

                string info = "Отделы:\n";

                if (departments.Count == 0)
                {
                    return Result<string>.Ok("Отделов нет.", "Информация составлена");
                }

                for (int i = 0; i < departments.Count; i++)
                {
                    info += $"Имя: {departments[i].Name} Id: {departments[i].Id}\n";
                }
                return Result<string>.Ok(info, "Информация составлена");
            }
            else
            {
                return Result<string>.Fail(result.Message);
            }
        }


        public Result<Department> ChangeNameById(int id, string newName)
        {
            Result<Department> resultDepartment = _repository.ChangeNameById(id, newName);

            if (resultDepartment.Success)
            {
                return Result<Department>.Ok(resultDepartment.Data, resultDepartment.Message);
            }
            else
            {
                return Result<Department>.Fail(resultDepartment.Message);
            }

        }

        public Result<Department> DeleteById(int id)
        {
            Result<Department> resultDepartment = _repository.DeleteById(id);

            if (resultDepartment.Success)
            {
                return Result<Department>.Ok(resultDepartment.Data, resultDepartment.Message);
            }
            else
            {
                return Result<Department>.Fail(resultDepartment.Message);
            }
        }

        public Result<Department> GetById(int id)
        {
            Result<Department> resultDepartment = _repository.GetById(id);

            if (resultDepartment.Success)
            {
                return Result<Department>.Ok(resultDepartment.Data, resultDepartment.Message);
            }
            else
            {
                return Result<Department>.Fail(resultDepartment.Message);
            }
        }

        public Result<Department> Create(string name)
        {
            Department department = new Department(name);
            department.Id = _idGeneratorService.GenerateID();

            Result<Department> resultDepartment = _repository.Add(department);

            if (resultDepartment.Success)
            {
                return Result<Department>.Ok(resultDepartment.Data, resultDepartment.Message);
            }
            else
            {
                return Result<Department>.Fail(resultDepartment.Message);
            }
        }
        #endregion Repository
    }
}
