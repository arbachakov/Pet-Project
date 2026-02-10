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
        private readonly WorkerRepository _workerRespository;
        private readonly IdGeneratorService _idGeneratorService;

        public WorkerService(WorkerRepository workerRespository, 
            IdGeneratorService idGeneratorService)
        {
            _workerRespository = workerRespository;
            _idGeneratorService = idGeneratorService;
        }

        public List<Worker> GetAll()
        {
            return _workerRespository.GetAll();
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
            if (_workerRespository.ChangeNameById(id, newName))
            { return true; }
            return false;         

        }

        public bool ChangeSernameById(int id, string newSername)
        {
            if(_workerRespository.ChangeSernameById(id, newSername)) 
            { return true; }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (_workerRespository.DeleteById(id))
            { return true; }
            return false;
        }

        public Worker GetById(int id)
        {
            return _workerRespository.GetById(id);
        }

        public Worker Create(string name)
        {
            Worker worker = new Worker(name);
            worker.Id = _idGeneratorService.GenerateID();
            _workerRespository.Add(worker);
            return worker;
        }

        //public Manager CreateManager(string name, string sername)
        //{
        //    Manager manager = new Manager(name, sername);
        //    manager.Id = _idGeneratorService.GenerateID();
        //    _workerRespository.Add(manager);
        //    return manager;
        //}

        //public ISAdmin CreateISAdmin(string name, string sername)
        //{
        //    ISAdmin iSAdmin = new ISAdmin(name, sername);
        //    iSAdmin.Id = _idGeneratorService.GenerateID();
        //    _workerRespository.Add(iSAdmin);
        //    return iSAdmin;
        //}

        //public ServerAdmin CreateServerAdmin(string name, string sername)
        //{
        //    ServerAdmin serverAdmin = new ServerAdmin(name, sername);
        //    serverAdmin.Id = _idGeneratorService.GenerateID();
        //    _workerRespository.Add(serverAdmin);
        //    return serverAdmin;
        //}

        //public NETAdmin CreateNETAdmin(string name, string sername)
        //{
        //    NETAdmin netAdmin = new NETAdmin(name, sername);
        //    netAdmin.Id = _idGeneratorService.GenerateID();
        //    _workerRespository.Add(netAdmin);
        //    return netAdmin;
        //}


    }
}
