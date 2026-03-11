using Pet_Project.Models;
using Pet_Project.Repositories;
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

        public void AddRelation(Worker worker, IS iS)
        {
            WorkerIS[worker] = iS;
            ISWorker[iS] = worker;
        }

        public void AddRelation(IS iS, Worker worker)
        {
            WorkerIS[worker] = iS;
            ISWorker[iS] = worker;
        }


    }
}
