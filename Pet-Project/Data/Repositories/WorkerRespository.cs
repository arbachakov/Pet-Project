using Pet_Project.Core;
using Pet_Project.Data.HelpModel;
using Pet_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Data.Repositories
{
    internal class WorkerRespository
    {
        // TODO Реализовать через лист

        private OfficeTree _tree = new OfficeTree();

        public void AddWorker(Worker worker) => _tree.Add(worker);
        public Worker GetWorkerById(int id) => _tree.GetWorkerById(id);
        public List<Worker> GetAllWorkers() => _tree.GetAllWorkers();

        public void ChangeWorkerNameById(int id, string newName)
        {
            // ВОПРОС Почему это работает??
            IWorkable worker = _tree.GetWorkerById(id);

            worker.Name = newName;
        }

        public void ChangeWorkerSernameById(int id, string newSername)
        {
            Worker worker = _tree.GetWorkerById(id);

            worker.Sername = newSername;
        }

        public bool DeleteWorker(int id)
        {
            bool deleted = _tree.Remove(id);
            return deleted;
        }
    }
}
