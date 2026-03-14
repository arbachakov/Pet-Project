using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Pattern;

namespace Pet_Project.Repositories
{
    internal class WorkerRepository : IRepository<Worker>
    {
        private List<Worker> _workers = new List<Worker>();

        public Result<List<Worker>> GetAll()
        {
            return Result<List<Worker>>.Ok(_workers, "Список получен из репозитория");
        }

        public Result<Worker> Add(Worker worker)
        {
            _workers.Add(worker);
            return Result<Worker>.Ok(worker,$"Рабочий {worker.Id} добавлен в репозиторий");
        }
            

        public Result<Worker> GetById(int id)
        {
            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i].Id == id)
                    return Result<Worker>.Ok(_workers[i], $"Рабочий {_workers[i].Id} найден");
            }
            return Result<Worker>.Fail("Рабочий не найден в репозитории");
        }


        public Result<Worker> ChangeNameById(int id, string newName)
        {
            Result<Worker> result = GetById(id);

            if(result.Success)
            {
                Worker worker = result.Data;
                string oldName = worker.Name;
                worker.Name = newName;
                return Result<Worker>.Ok(worker, $"У работника с id {worker.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<Worker>.Fail(result.Message);
            }
        }

        public Result<Worker> ChangeSernameById(int id, string newSername)
        {
            Result<Worker> result = GetById(id);

            if (result.Success)
            {
                Worker worker = result.Data;
                string oldSername = worker.Sername;
                worker.Sername = newSername;
                return Result<Worker>.Ok(worker, $"У работника с id {worker.Id} изменено имя c {oldSername} на {newSername}");
            }
            else
            {
                return Result<Worker>.Fail(result.Message);
            }
        }

        public Result<Worker> DeleteById(int id)
        {
            Result<Worker> result = GetById(id);

            if(result.Success)
            {
                Worker worker = result.Data;
                _workers.Remove(worker);
                return Result<Worker>.Ok(worker, $"Рабочий {worker.Id} удален"); ;
            }
            else
            {
                return Result<Worker>.Fail(result.Message);
            }
        }
    }
}
