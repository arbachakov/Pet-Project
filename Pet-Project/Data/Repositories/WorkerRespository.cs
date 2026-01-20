using Pet_Project.Core;
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
        private OfficeTree _tree = new OfficeTree();

        public void AddWorker(Worker worker) => _tree.Add(worker);
        public Worker GetWorker(int id) => _tree.FindById(id);
        // TODO Реализовать вывод всех сотрудников
        //public string PrintAllWorkers() => _tree.PrintInOrder();
    }
}
