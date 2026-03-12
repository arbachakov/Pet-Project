using Pet_Project.Models;
using Pet_Project.Repositories;
using Pet_Project.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Registries
{
    internal class ISAdmRegistry
    {
        private readonly ISRepository _repository;

        public ISAdmRegistry(ISRepository repository)
        {
            _repository = repository;
        }

        private  Dictionary<Worker, IS> WorkerIS = new Dictionary<Worker, IS>();

        private Dictionary<IS, Worker> ISWorker = new Dictionary<IS, Worker>();


        public Result<Dictionary<Worker, IS>> GetWorkerISDict()
        {
            return Result<Dictionary<Worker, IS>>.Ok(WorkerIS, "Словарь получен");
        }

        public Result<Dictionary<IS, Worker>> GetISWorkerDict()
        {
            return Result<Dictionary<IS, Worker>>.Ok(ISWorker, "Словарь получен");
        }

        public Result<Worker> AddRelation(Worker worker, IS iS)
        {
            WorkerIS[worker] = iS;
            ISWorker[iS] = worker;

            return Result<Worker>.Ok(worker, $"Добавлена связь {worker.Name} - {iS.Name}");
        }

        public Result<IS> AddRelation(IS iS, Worker worker)
        {
            WorkerIS[worker] = iS;
            ISWorker[iS] = worker;

            return Result<IS>.Ok(iS, $"Добавлена связь {worker.Name} - {iS.Name}");
        }

        public Result<Worker> RemoveRelation(Worker worker, IS iS)
        {
            if (WorkerIS[worker] == iS && ISWorker[iS] == worker)
            {
                WorkerIS.Remove(worker);
                ISWorker.Remove(iS);
                return Result<Worker>.Ok(worker, $"Удалена связь {worker.Name} - {iS.Name}");
            }
            else
            {
                return Result<Worker>.Fail($"Связь {worker.Name} - {iS.Name} не найдена.");
            }
        }



        //public Result<IS> RemoveRelation(Worker worker, IS iS)
        //{
        //    if (WorkerIS[worker] == iS && ISWorker[iS] == worker)
        //    {
        //        WorkerIS.Remove(worker);
        //        ISWorker.Remove(iS);
        //        return Result<IS>.Ok(iS, $"Удалена связь {worker.Name} - {iS.Name}");
        //    }
        //    else
        //    {
        //        return Result<IS>.Fail($"Связь {worker.Name} - {iS.Name} не найдена.");
        //    }
        //}


    }
}
