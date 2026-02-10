using Pet_Project.Interface;
using Pet_Project.Interfaces;
using Pet_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class WorkerRepository : IRepository<Worker>
    {
        private List<Worker> _workers = new List<Worker>();

        public List<Worker> GetAll()
            { return _workers; }

        public bool Add(Worker worker)
        {
            _workers.Add(worker);
            return true;
        }
            

        public Worker GetById(int id)
        {
            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i].Id == id)
                    return _workers[i];
            }
            return null;
        }


        public bool ChangeNameById(int id, string newName)
        {
            Worker worker = GetById(id);
            if (worker != null) 
            { 
                worker.Name = newName; 
                return true; 
            }
            return false;
        }

        public bool ChangeSernameById(int id, string newSername)
        {
            Worker worker = GetById(id);
            if (worker != null)
            {
                worker.Sername = newSername;
                return true;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            Worker worker = GetById(id);
            if (worker != null)
            {
                _workers.Remove(worker);
                return true;
            }
            return false;
            
        }

        //public void ChangeNameById(int id, string newName)
        //{
        //    // ВОПРОС Почему это работает??
        //    IWorkable worker = _workers.GetWorkerById(id);

        //    worker.Name = newName;
        //}




    }
}
