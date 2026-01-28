using Pet_Project.Data.Models;
using Pet_Project.Data.Models.OfficeStructure;
using Pet_Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Core.Services
{
    internal class WorkerService
    {
        private readonly WorkerRespository _workerRespository;
        private readonly IdGeneratorService _idGeneratorService; // ВОПРОС Уместно ли применение сервиса здесь или сервисы должны находиться на одном уровне?

        public WorkerService(WorkerRespository workerRespository, IdGeneratorService idGeneratorService)
        {
            _workerRespository = workerRespository;
            _idGeneratorService = idGeneratorService;
        }

        // ВОПРОС Реализовать Обязанности сотрудников в отдельном сервисе?

        public List<string> GetAllWorkers()
        {
            var workers = _workerRespository.GetAllWorkers();
            if (workers.Count == 0)
                return null;

            List<string> result = new List<string> { };

            for (int i = 0; i < workers.Count; i++)
            {
                string line = $"Имя: {workers[i].Name} " +
                    $"Фамилия: {workers[i].Sername} " +
                    $"ID: {workers[i].ID}";
                result.Add(line);
            }
            return result;
        }

        public void ChangeWorkerNameById(int id, string newName)
        {
            _workerRespository.ChangeWorkerNameById(id, newName);
        }

        public void ChangeWorkerSernameById(int id, string newSername)
        {
            _workerRespository.ChangeWorkerSernameById(id, newSername);
        }

        public string GetWorkerById(int id)
        {
            Worker worker = _workerRespository.GetWorkerById(id);
            string result = worker.Name + "," + worker.Sername + "," + worker.ID;
            return result;
        }

        public Manager CreateManager(string name, string sername)
        {
            Manager manager = new Manager(name,sername);
            manager.ID = _idGeneratorService.GenerateID();
            _workerRespository.AddWorker(manager);
            return manager;
        }

        public ISAdmin CreateISAdmin(string name, string sername)
        {
            ISAdmin ISAdmin = new ISAdmin(name, sername);
            ISAdmin.ID = _idGeneratorService.GenerateID();
            _workerRespository.AddWorker(ISAdmin);
            return ISAdmin;
        }

        public ServerAdmin CreateServerAdmin(string name, string sername)
        {
            ServerAdmin ServerAdmin = new ServerAdmin(name, sername);
            ServerAdmin.ID = _idGeneratorService.GenerateID();
            _workerRespository.AddWorker(ServerAdmin);
            return ServerAdmin;
        }

        public NETAdmin CreateNETAdmin(string name, string sername)
        {
            NETAdmin NETAdmin = new NETAdmin(name, sername);
            NETAdmin.ID = _idGeneratorService.GenerateID();
            _workerRespository.AddWorker(NETAdmin);
            return NETAdmin;
        }

        public bool DeleteWorkerById(int id)
        {
            bool deleted = _workerRespository.DeleteWorker(id);
            return deleted;
        }
    }
}
