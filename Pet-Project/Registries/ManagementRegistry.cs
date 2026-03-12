using Pet_Project.Model;
using Pet_Project.Models;
using Pet_Project.Pattern;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Registries
{
    internal class ManagementRegistry
    {
        private readonly WorkerRepository _repository;

        public ManagementRegistry(WorkerRepository repository)
        {
            _repository = repository;
        }

        // ВОПРОС Стоит придумать другое наименование?
        private Dictionary<Worker, Worker> WorkerDict = new Dictionary<Worker, Worker>();


        public Result<Dictionary<Worker, Worker>> GetWorkerDict()
        {
            return Result<Dictionary<Worker, Worker>>.Ok(WorkerDict, "Словарь получен");
        }

        public Result<Worker> AddRelation(Worker manager, Worker worker)
        {
            WorkerDict[manager] = worker;

            return Result<Worker>.Ok(manager, $"Добавлена связь {manager.Name} - {worker.Name}");
        }

        public Result<Worker> RemoveRelation(Worker manager, Worker worker)
        {
            if (WorkerDict[manager] == worker)
            {
                WorkerDict.Remove(worker);
                return Result<Worker>.Ok(manager, $"Удалена связь {manager.Name} - {worker.Name}");
            }
            else
            {
                return Result<Worker>.Fail($"Связь {manager.Name} - {worker.Name} не найдена.");
            }
        }
    }
}
