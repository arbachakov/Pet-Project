using Pet_Project.Interfaces;
using Pet_Project.Model.WorkerKindes;
using Pet_Project.Models;
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
    internal class WorkerService : IServicable<Worker>
    {
        private readonly WorkerRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public WorkerService(WorkerRepository workerRespository, 
            IdGeneratorService idGeneratorService)
        {
            _repository = workerRespository;
            _idGeneratorService = idGeneratorService;
        }

        public List<Worker> GetAll()
        {
            return _repository.GetAll();
        }

        public string ViewAll()
        {
            string workersInfo = "Сотрудники:\n";
            List<Worker> workers = GetAll();
            if (workers.Count == 0)
            { return "Рабочих нет("; }
            for (int i = 0; i < workers.Count; i++)
            {
                workersInfo += $"Имя: {workers[i].Name} Фамилия: {workers[i].Sername} Id: {workers[i].Id}\n";
            }
            return workersInfo;
        }

        public bool ChangeNameById(int id, string newName)
        {
            if (_repository.ChangeNameById(id, newName))
            { return true; }
            return false;         

        }

        public bool ChangeSernameById(int id, string newSername)
        {
            if(_repository.ChangeSernameById(id, newSername)) 
            { return true; }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (_repository.DeleteById(id))
            { return true; }
            return false;
        }

        public Worker GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Worker Create(string name)
        {
            Worker worker = new Worker(name);
            worker.Id = _idGeneratorService.GenerateID();
            _repository.Add(worker);
            return worker;
        }

    }
}
