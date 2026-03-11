using Pet_Project.Interfaces;
using Pet_Project.Model.WorkerKindes;
using Pet_Project.Models;
using Pet_Project.Pattern;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Services
{
    internal class WorkerService //: IServicable<Worker>
    {
        private readonly WorkerRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public WorkerService(WorkerRepository workerRespository, 
            IdGeneratorService idGeneratorService)
        {
            _repository = workerRespository;
            _idGeneratorService = idGeneratorService;
        }

        public Result<List<Worker>> GetAll()
        {
            Result<List<Worker>> resultWorker = _repository.GetAll();

            if (resultWorker.Success)
            {
                return Result<List<Worker>>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else
            {
                return Result<List<Worker>>.Fail(resultWorker.Message);
            }
        }


        public Result<Worker> ChangeNameById(int id, string newName)
        {
            Result<Worker> resultWorker = _repository.ChangeNameById(id, newName);

            if (resultWorker.Success)
            {
                return Result<Worker>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else 
            {
                return Result<Worker>.Fail(resultWorker.Message);
            }

        }

        public Result<Worker> ChangeSernameById(int id, string newSername)
        {
            Result<Worker> resultWorker = _repository.ChangeNameById(id, newSername);

            if (resultWorker.Success)
            {
                return Result<Worker>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else 
            {
                return Result<Worker>.Fail(resultWorker.Message);
            }
        }

        public Result<Worker> DeleteById(int id)
        {
            Result<Worker> resultWorker = _repository.DeleteById(id);

            if (resultWorker.Success)
            {
                return Result<Worker>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else
            {
                return Result<Worker>.Fail(resultWorker.Message);
            }
        }

        public Result<Worker> GetById(int id)
        {
            Result<Worker> resultWorker = _repository.GetById(id);

            if (resultWorker.Success)
            {
                return Result<Worker>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else
            {
                return Result<Worker>.Fail(resultWorker.Message);
            }
        }

        public Result<Worker> Create(string name)
        {
            Worker worker = new Worker(name);
            worker.Id = _idGeneratorService.GenerateID();

            Result<Worker> resultWorker = _repository.Add(worker);

            if (resultWorker.Success)
            {
                return Result<Worker>.Ok(resultWorker.Data, resultWorker.Message);
            }
            else
            {
                return Result<Worker>.Fail(resultWorker.Message);
            }
        }

    }
}
